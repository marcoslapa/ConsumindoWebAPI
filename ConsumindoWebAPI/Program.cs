using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsumindoWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o id ou deixe-o em branco acaso queira buscar todos os posts!");
            string id = Console.ReadLine();

            GetData(id);
            Console.ReadKey();
        }

        public static async void GetData(string id)
        {
            HttpClient httpClient = new HttpClient();

            string url = $"http://jsonplaceholder.typicode.com/posts/{id}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string dados = await response.Content.ReadAsStringAsync();

            if (String.IsNullOrEmpty(id))
            {
                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(dados);
                foreach(Post p in posts)
                {
                    Console.WriteLine("**********************************************");
                    Console.WriteLine($"Post {p.Id}");
                    Console.WriteLine("**********************************************");
                    PrinPost(p);
                    Console.WriteLine("**********************************************");
                }
            }
            else
            {
                Post p = JsonConvert.DeserializeObject<Post>(dados);
                PrinPost(p);
            }
        }

        private static void PrinPost(Post p)
        {
            Console.WriteLine($"Titulo: {p.Title}");
            Console.WriteLine($"Texto: {p.Body}");
        }
    }
}

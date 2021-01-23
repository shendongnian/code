    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => MainAsync());
            Console.ReadLine();
        }
        static async Task MainAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6740");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("", "login")
                });
                var result = await client.PostAsync("/api/Membership/exists", content);
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
            }
        }
    }

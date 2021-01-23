        static void Main(string[] args)
        {
            MakeRequest();       
            Console.ReadLine();
        }
        private static async void MakeRequest()
        {
            await UseHttpClient();
            UseWebClient();
        }
        private static async Task UseHttpClient()
        {
            Console.WriteLine("=== HttpClient ==");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("http://www.google.com"));
            Console.WriteLine("HttpClient requesting...");
            var response = await client.SendAsync(request);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result.Substring(0,100));
            Console.WriteLine("HttpClient done");
        }
        private static void UseWebClient()
        {
            Console.WriteLine("=== WebClient ==");
            var webClient = new WebClient();
            webClient.DownloadStringAsync(new Uri("http://www.google.com"));
            Console.WriteLine("WebClient requesting...");
            webClient.DownloadStringCompleted += (sender, eventArgs) => Console.WriteLine(eventArgs.Result.Substring(0,100));
            Console.WriteLine("WebClient done.");
        }

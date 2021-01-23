        static void Main(string[] args)
        {
            GetResponse();
            Console.ReadLine();
        }
        private static async Task<WebResponse> GetResponse()
        {
            var webRequest = WebRequest.Create("http://www.google.com");
            Task<WebResponse> response = webRequest.GetResponseAsync();
            Console.WriteLine(new StreamReader(response.Result.GetResponseStream()).ReadToEnd());
            return response.Result;
        }

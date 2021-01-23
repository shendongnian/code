    namespace TaskTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Send();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
    
            private static void Send()
            {
                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> responseTask = client.GetAsync("http://google.com");
                responseTask.ContinueWith(x => Print(x));
            }
    
            private static void Print(Task<HttpResponseMessage> httpTask)
            {
                Task<string> task = httpTask.Result.Content.ReadAsStringAsync();
                Task continuation = task.ContinueWith(t =>
                {
                    Console.WriteLine("Result: " + t.Result);
                });
            }
        }
    }

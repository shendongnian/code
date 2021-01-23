       private static void Main()
        {
            for (var i = 0; i < 1000000; i++)
            {
                Go(i, Thread.CurrentThread.ManagedThreadId);
            }
            Console.Read();
        }
        private static async Task Go(int counter, int threadId)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var webClient = new WebClient())
            {
                await webClient.DownloadStringTaskAsync(
                                 new Uri("http://stackoverflow.com"));
            }
                //...
        });

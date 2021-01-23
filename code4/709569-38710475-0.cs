    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");
            StartTest().Wait();
            Console.ReadLine();
            Console.WriteLine("Complete Main");
        }
        static async Task StartTest()
        {
            var cts = new CancellationTokenSource();
            // ***Use ToArray to execute the query and start the download tasks. 
            Task<bool>[] tasks = new Task<bool>[2];
            tasks[0] = LongRunningTask("", 20, cts.Token);
            tasks[1] = Heartbeat("", 1, cts.Token);
            // ***Call WhenAny and then await the result. The task that finishes 
            // first is assigned to firstFinishedTask.
            Task<bool> firstFinishedTask = await Task.WhenAny(tasks);
            Console.WriteLine("first task Finished.");
            // ***Cancel the rest of the downloads. You just want the first one.
            cts.Cancel();
            // ***Await the first completed task and display the results. 
            // Run the program several times to demonstrate that different
            // websites can finish first.
            var isCompleted = await firstFinishedTask;
            Console.WriteLine("isCompleted:  {0}", isCompleted);
        }
        private static async Task<bool> LongRunningTask(string id, int sleep, CancellationToken ct)
        {
            Console.WriteLine("Starting long task");
            
            await Task.Delay(TimeSpan.FromSeconds(sleep));
            Console.WriteLine("Completed long task");
            return true;
        }
        private static async Task<bool> Heartbeat(string id, int sleep, CancellationToken ct)
        {
            while(!ct.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(sleep));
                Console.WriteLine("Heartbeat Task Sleep: {0} Second", sleep);
            }
            return true;
        }
    }
}

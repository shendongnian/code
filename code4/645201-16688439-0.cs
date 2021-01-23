    class Program
    {
        static void Main(string[] args)
        {
            List<int> results;
            //Using raw Wait Handle
            ManualResetEvent handle = new ManualResetEvent(false);
            Thread thread = new Thread(o =>
                {
                    //Long running process
                    results = LongRunningTask();
                    handle.Set();
                });
            thread.Start();
            handle.WaitOne();
            Console.WriteLine("Thread completed");
            //Using Tasks
            Task<List<int>> task = Task<List<int>>.Factory.StartNew(LongRunningTask);
            results = task.Result;
            Console.WriteLine("Task completed");
            //Using async/await
            results = LongRunningTaskAsync().Result;
            Console.WriteLine("Async Method completed");
            Console.ReadLine();
        }
        public static List<int> LongRunningTask()
        {
            Thread.Sleep(5000);
            return new List<int>();
        }
        public static async Task<List<int>> LongRunningTaskAsync()
        {
            return await Task<List<int>>.Factory.StartNew(LongRunningTask);
        }
    }

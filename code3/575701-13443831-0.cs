    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            TaskFactory taskfactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var task = taskfactory.StartNew(() => { DoWork("Thread " + i); });
                Console.WriteLine(string.Format("Started thread {0}", i));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());  
        }
        static void DoWork(string threadname)
        {
            int sleeptime = random.Next(10) * 1000;
            Console.WriteLine(string.Format("Thread {0} sleeping {1}ms", threadname, sleeptime));
            Thread.Sleep(random.Next(10) * 1000);
        }
    }

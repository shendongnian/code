    class Program
    {
        private static IList<BackgroundWorker> workers;
        private static Random ran;
        private static int activeWorkersCount;
    
        static void Main(string[] args)
        {            
            workers = new List<BackgroundWorker>();
            DoWork();
                
            while (activeWorkersCount > 0)
            {
                Thread.Sleep(200);
            }
    
            Console.WriteLine("Waiting for all workers to finish...");
            Console.ReadLine();
        }
            
        private static void DoWork() // recursive method
        {
            Thread.Sleep(100);
    
            var newWorker = new BackgroundWorker();
    
            newWorker.DoWork += BackgroundWorkerDoWork;
            newWorker.RunWorkerCompleted += (o, e) =>
                                                {
                                                    Console.WriteLine("[E] Worker finished");
                                                    Interlocked.Decrement(ref activeWorkersCount);
                                                };
            Interlocked.Increment(ref activeWorkersCount);
            newWorker.RunWorkerAsync();
        }
    
        private static void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("[S] Worker started");
            ran = new Random();
            Thread.Sleep(ran.Next(500, 1000));
            if (ran.Next(1, 5) != 1) // if = 1 then to stop recursion
            {
                DoWork();
            }
        }
    }

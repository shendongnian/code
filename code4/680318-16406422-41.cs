    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("100 iterations in ticks");
            p.TimeMethod("Semaphore", p.AThreadSemaphore);
            p.TimeMethod("SemaphoreSlim", p.AThreadSemaphoreSlim);
            p.TimeMethod("Monitor.Enter", p.AThreadMonitorEnter);
            p.TimeMethod("Lock", p.AThreadLock);
            Console.WriteLine("Ticks per millisecond: {0}", TimeSpan.TicksPerMillisecond);
        }
        private readonly Semaphore semLock = new Semaphore(1, 1);
        private readonly SemaphoreSlim semSlimLock = new SemaphoreSlim(1, 1);
        private readonly object _lockObject = new object();
        const int Iterations = (int)1E6;
        int sharedResource = 0;
        void TimeMethod(string description, Action a)
        {
            sharedResource = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < Iterations; i++)
            {
                a();
            }
            sw.Stop();
            Console.WriteLine("{0:0.000} ({1})", (double)sw.ElapsedTicks * 100d / (double)Iterations, description);
        }
        void TimeMethod2Threads(string description, Action a)
        {
            sharedResource = 0;
            Stopwatch sw = new Stopwatch();
            using (Task t1 = new Task(() => IterateAction(a, Iterations / 2)))
            using (Task t2 = new Task(() => IterateAction(a, Iterations / 2)))
            {
                sw.Start();
                t1.Start();
                t2.Start();
                Task.WaitAll(t1, t2);
                sw.Stop();
            }
            Console.WriteLine("{0:0.000} ({1})", (double)sw.ElapsedTicks * (double)100 / (double)Iterations, description);
        }
        private static void IterateAction(Action a, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                a();
            }
        }
        void AThreadSemaphore()
        {
            semLock.WaitOne();
            try {
                sharedResource++;
            }
            finally {
                semLock.Release();
            }
        }
        void AThreadSemaphoreSlim()
        {
            semSlimLock.Wait();
            try
            {
                sharedResource++;
            }
            finally
            {
                semSlimLock.Release();
            }
        }
        void AThreadMonitorEnter()
        {
            Monitor.Enter(_lockObject);
            try
            {
                sharedResource++;
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }
        }
        void AThreadLock()
        {
            lock (_lockObject)
            {
                sharedResource++;
            }
        }
    }

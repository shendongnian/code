    class Program
    {
        // Max 100 items in queue
        private static readonly Semaphore WorkLimiter = new Semaphore(100, 100);
        static void Main(string[] args)
        {
            Console.WriteLine(2);
            Console.WriteLine(3);
            Console.WriteLine(5);
            Console.WriteLine(7);
            Console.WriteLine(11);
            Console.WriteLine(13);
            Console.WriteLine(17);
            for (long i = 19; i < Int64.MaxValue; i = i + 2)
            {
                if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0 || i % 11 == 0 || i % 13 == 0 || i % 17 == 0)
                    continue;
                // Get one of the 100 "allowances" to add to the queue.
                WorkLimiter.WaitOne();
                ThreadPool.QueueUserWorkItem(CheckForPrime, i);
            }
            Console.Read();
        }
        private static void CheckForPrime(object i)
        {
            var i1 = i as long?;
            try
            {
                var val = Math.Sqrt(i1.Value);
                for (long j = 19; j <= val; j = j + 2)
                {
                    if (i1%j == 0) return;
                }
                Console.WriteLine(i1);
            }
            finally
            {
                // Allow another add to the queue
                WorkLimiter.Release();
            }
        }
    }

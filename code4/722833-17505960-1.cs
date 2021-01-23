    namespace Demo
    {
        class Program
        {
            Stopwatch sw = Stopwatch.StartNew();
            object locker = new object();
            ConcurrentQueue<long> queue = new ConcurrentQueue<long>();
            Barrier barrier = new Barrier(9);
            void run()
            {
                Console.WriteLine("Starting");
                for (int i = 0; i < 8; ++i)
                    Task.Run(()=>test());
                barrier.SignalAndWait(); // Make sure all threads start "simultaneously"
                Thread.Sleep(2000); // Plenty of time for all the threads to finish.
                Console.WriteLine("Stopped");
                foreach (var elapsed in queue)
                    Console.WriteLine(elapsed);
                Console.ReadLine();
            }
            void test()
            {
                barrier.SignalAndWait(); // Make sure all threads start "simultaneously".
                for (int i = 0; i < 10; ++i)
                    queue.Enqueue(elapsed());
            }
            long elapsed()
            {
                lock (locker)
                {
                    return sw.ElapsedTicks;
                }
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }

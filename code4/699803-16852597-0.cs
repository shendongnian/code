    using System;
    using System.Linq;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            Random rng = new Random();
            int numberOfThreadsRunning;
            void Run()
            {
                int maxThreads = 8;
                int maxCalls = 30;
                Enumerable.Range(1, maxCalls)
                    .AsParallel()
                    .WithDegreeOfParallelism(maxThreads)
                    .Select(worker)
                    .Count(); // .Count() isjust a hack to make it enumerate.
            }
            int worker(int id)
            {
                int n = Interlocked.Increment(ref numberOfThreadsRunning);
                Console.WriteLine(id + " is starting. #threads now = " + n);
                Thread.Sleep(rng.Next(1000, 2000));
                Console.WriteLine(id + " is stopping.");
                Interlocked.Decrement(ref numberOfThreadsRunning);
                return id; // Return value not actually used.
            }
            static void Main()
            {
                new Program().Run();
            }
        }
    }

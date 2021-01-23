    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Program().run();
            }
            void run()
            {
                int threadCount = 4;
                for (int i = 0; i < threadCount; ++i)
                {
                    int workerId = i;
                    Task.Factory.StartNew(() => worker(workerId));
                }
                for (int i = 0; i < 100; ++i)
                {
                    Console.WriteLine("Queueing work item {0}", i);
                    queue.Add(i);
                    Thread.Sleep(50);
                }
                Console.WriteLine("Stopping adding.");
                queue.CompleteAdding();
                Console.ReadLine();
            }
            void worker(int workerId)
            {
                Console.WriteLine("Worker {0} is starting.", workerId);
                foreach (var workItem in queue.GetConsumingEnumerable())
                {
                    Console.WriteLine("Worker {0} is processing item {1}", workerId, workItem);
                    Thread.Sleep(100); // Simulate work.
                }
                Console.WriteLine("Worker {0} is stopping.", workerId);
            }
            BlockingCollection<int> queue = new BlockingCollection<int>();
        }
    }

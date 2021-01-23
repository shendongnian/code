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
                Task[] workers = new Task[threadCount];
                Task.Factory.StartNew(consumer);
                for (int i = 0; i < threadCount; ++i)
                {
                    int workerId = i;
                    Task task = new Task(() => worker(workerId));
                    workers[i] = task;
                    task.Start();
                }
                for (int i = 0; i < 100; ++i)
                {
                    Console.WriteLine("Queueing work item {0}", i);
                    inputQueue.Add(i);
                    Thread.Sleep(50);
                }
                Console.WriteLine("Stopping adding.");
                inputQueue.CompleteAdding();
                Task.WaitAll(workers);
                outputQueue.CompleteAdding();
                Console.WriteLine("Done.");
                Console.ReadLine();
            }
            void worker(int workerId)
            {
                Console.WriteLine("Worker {0} is starting.", workerId);
                foreach (var workItem in inputQueue.GetConsumingEnumerable())
                {
                    Console.WriteLine("Worker {0} is processing item {1}", workerId, workItem);
                    Thread.Sleep(100);          // Simulate work.
                    outputQueue.Add(workItem);  // Output completed item.
                }
                Console.WriteLine("Worker {0} is stopping.", workerId);
            }
            void consumer()
            {
                Console.WriteLine("Consumer is starting.");
                foreach (var workItem in outputQueue.GetConsumingEnumerable())
                {
                    Console.WriteLine("Consumer is using item {0}", workItem);
                    Thread.Sleep(25);
                }
                Console.WriteLine("Consumer is finished.");
            }
            BlockingCollection<int> inputQueue = new BlockingCollection<int>();
            BlockingCollection<int> outputQueue = new BlockingCollection<int>();
        }
    }

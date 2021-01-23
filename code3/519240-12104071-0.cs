    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AsyncTakeFromBlockingCollection
    {
        class Program
        {
            static void Main(string[] args)
            {
                var queue = new ConcurrentQueue<string>();
    
                var producer1 = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 10; i += 1)
                    {
                        queue.Enqueue("=======");
                        Thread.Sleep(10);
                    }
                });
    
                var producer2 = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 10; i += 1)
                    {
                        queue.Enqueue("*******");
                        Thread.Sleep(3);
                    }
                });
    
                CreateConsumerTask("One  ", 3, queue);
                CreateConsumerTask("Two  ", 4, queue);
                CreateConsumerTask("Three", 7, queue);
    
                producer1.Wait();
                producer2.Wait();
                Console.WriteLine("  Producers Finished");
                Console.ReadLine();
            }
    
            static void CreateConsumerTask(string taskName, int sleepTime, ConcurrentQueue<string> queue)
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        string result;
                        if (queue.TryDequeue(out result))
                        {
                            Console.WriteLine("  {0} consumed {1}", taskName, result);
                        }
                        Thread.Sleep(sleepTime);
                    }
                });
            }
        }
    }

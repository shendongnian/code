    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    
    namespace ConcurrentCollections
    {
        class Program
        {
            static void Main()
            {
                var cache = new ConcurrentDictionary<string, int>();
    
                for (int threadId = 0; threadId < 2; threadId++)
                {
                    new Thread(
                        () =>
                        {
                            while (true)
                            {
                                var newValue = cache.AddOrUpdate("key", 0, (key, value) => value + 1);
                                Console.WriteLine("Thread {0} incremented value to {1}",
                                    Thread.CurrentThread.ManagedThreadId, newValue);
                            }
    
                        }).Start();
                }
    
                Thread.Sleep(TimeSpan.FromMinutes(2));
            }
        }
    }

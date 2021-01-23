    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                ThreadPool.SetMinThreads(10, 0); // To help the demo; not needed in real code.
                var plant = new ProcessingPlant();
                plant.Process();
                Console.WriteLine("Work complete.");
            }
        }
        public sealed class ProcessingPlant
        {
            private readonly BlockingCollection<string> _queue = new BlockingCollection<string>();
            public void Process()
            {
                Parallel.Invoke(producer, consumers);
            }
            private void producer()
            {
                for (int i = 0; i < 100; ++i)
                {
                    string item = i.ToString();
                    Console.WriteLine("Producer is queueing {0}", item);
                   _queue.Add(item);  // <- Here's where we add an item to the queue.
                    Thread.Sleep(0);
                }
                _queue.CompleteAdding(); // <- Here's where we make all the consumers
            }                            //    exit their foreach loops.
            private void consumers()
            {
                Parallel.Invoke(
                    () =>  consumer(1),
                    () =>  consumer(2),
                    () =>  consumer(3),
                    () =>  consumer(4),
                    () =>  consumer(5)
                );
            }
            private void consumer(int id)
            {
                Console.WriteLine("Consumer {0} is starting.", id);
                foreach (var item in _queue.GetConsumingEnumerable()) // <- Here's where we remove items.
                {
                    Console.WriteLine("Consumer {0} read {1}", id, item);
                    Thread.Sleep(0);
                }
                Console.WriteLine("Consumer {0} is stopping.", id);
            }
        }
    }

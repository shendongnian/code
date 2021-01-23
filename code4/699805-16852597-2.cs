    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    namespace Demo
    {
        class DataForWorker
        {
            public int ID;
            public string Value;
        };
        class Program
        {
            Random rng = new Random();
            int numberOfThreadsRunning;
            void Run()
            {
                int maxThreads = 8;
                IEnumerable<DataForWorker> dataForWorkers = getDataForWorkers();
                dataForWorkers
                    .AsParallel()
                    .WithDegreeOfParallelism(maxThreads)
                    .ForAll(worker);
            }
            IEnumerable<DataForWorker> getDataForWorkers()
            {
                // Just return some dummy data.
                int numberOfDataItems = 30;
                return Enumerable.Range(1, numberOfDataItems).Select
                (
                    n => new DataForWorker
                    {
                        ID = n,
                        Value = n.ToString()
                    }
                );
            }
            void worker(DataForWorker data)
            {
                int n = Interlocked.Increment(ref numberOfThreadsRunning);
                Console.WriteLine("Thread " + data.ID + " is starting. #threads now = " + n);
                Thread.Sleep(rng.Next(1000, 2000));
                Console.WriteLine("Thread " + data.ID + " is stopping.");
                Interlocked.Decrement(ref numberOfThreadsRunning);
            }
            static void Main()
            {
                new Program().Run();
            }
        }
    }

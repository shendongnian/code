    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AsyncTest
    {
        class Program
        {
            class Worker
            {
                public int Id { get; set; }
                public int SleepTimeout { get; set; }
    
                public async Task DoWork()
                {
                    Console.WriteLine("Worker {0} started on thread {1} at {2}.",
                        Id, Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("hh:mm:ss.fff"));
                    await Task.Run(() => Thread.Sleep(SleepTimeout));
                    Console.WriteLine("Worker {0} stopped at {1}.",
                        Id, DateTime.Now.ToString("hh:mm:ss.fff"));
                }
            }
    
            static void Main(string[] args)
            {
                var workers = new List<Worker>
                {
                    new Worker { Id = 1, SleepTimeout = 3000 },
                    new Worker { Id = 2, SleepTimeout = 3000 },
                    new Worker { Id = 3, SleepTimeout = 3000 },
                    new Worker { Id = 4, SleepTimeout = 3000 },
                    new Worker { Id = 5, SleepTimeout = 3000 },
                };
    
                var startTime = DateTime.Now;
                Console.WriteLine("Starting test: Parallel.ForEach at {0}",
                    startTime.ToString("hh:mm:ss.fff"));
                PerformTest_ParallelForEach(workers);
                var endTime = DateTime.Now;
                Console.WriteLine("Test finished at {0} ({1} milliseconds).\n",
                    endTime.ToString("hh:mm:ss.fff"), (endTime - startTime).TotalMilliseconds);
    
                startTime = DateTime.Now;
                Console.WriteLine("Starting test: Task.WaitAll at {0}",
                    startTime.ToString("hh:mm:ss.fff"));
                PerformTest_TaskWaitAll(workers);
                endTime = DateTime.Now;
                Console.WriteLine("Test finished at {0} ({1} milliseconds).\n",
                    endTime.ToString("hh:mm:ss.fff"), (endTime - startTime).TotalMilliseconds);
    
                startTime = DateTime.Now;
                Console.WriteLine("Starting test: Task.WhenAll at {0}",
                    startTime.ToString("hh:mm:ss.fff"));
                var task = PerformTest_TaskWhenAll(workers);
                task.Wait();
                endTime = DateTime.Now;
                Console.WriteLine("Test finished at {0} ({1} milliseconds).\n",
                    endTime.ToString("hh:mm:ss.fff"), (endTime - startTime).TotalMilliseconds);
    
                Console.ReadKey();
            }
    
            static void PerformTest_ParallelForEach(List<Worker> workers)
            {
                Parallel.ForEach(workers, worker => worker.DoWork().Wait());
            }
    
            static void PerformTest_TaskWaitAll(List<Worker> workers)
            {
                Task.WaitAll(workers.Select(worker => worker.DoWork()).ToArray());
            }
    
            static Task PerformTest_TaskWhenAll(List<Worker> workers)
            {
                return Task.WhenAll(workers.Select(worker => worker.DoWork()));
            }
        }
    }

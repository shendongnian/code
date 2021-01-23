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
                public int Id;
                public int SleepTimeout;
    
                public async Task DoWork(DateTime testStart)
                {
                    var workerStart = DateTime.Now;
                    Console.WriteLine("Worker {0} started on thread {1}, beginning {2} seconds after test start.",
                        Id, Thread.CurrentThread.ManagedThreadId, (workerStart-testStart).TotalSeconds.ToString("F2"));
                    await Task.Run(() => Thread.Sleep(SleepTimeout));
                    var workerEnd = DateTime.Now;
                    Console.WriteLine("Worker {0} stopped; the worker took {1} seconds, and it finished {2} seconds after the test start.",
                       Id, (workerEnd-workerStart).TotalSeconds.ToString("F2"), (workerEnd-testStart).TotalSeconds.ToString("F2"));
                }
            }
    
            static void Main(string[] args)
            {
                var workers = new List<Worker>
                {
                    new Worker { Id = 1, SleepTimeout = 1000 },
                    new Worker { Id = 2, SleepTimeout = 2000 },
                    new Worker { Id = 3, SleepTimeout = 3000 },
                    new Worker { Id = 4, SleepTimeout = 4000 },
                    new Worker { Id = 5, SleepTimeout = 5000 },
                };
    
                var startTime = DateTime.Now;
                Console.WriteLine("Starting test: Parallel.ForEach...");
                PerformTest_ParallelForEach(workers, startTime);
                var endTime = DateTime.Now;
                Console.WriteLine("Test finished after {0} seconds.\n",
                    (endTime - startTime).TotalSeconds.ToString("F2"));
    
                startTime = DateTime.Now;
                Console.WriteLine("Starting test: Task.WaitAll...");
                PerformTest_TaskWaitAll(workers, startTime);
                endTime = DateTime.Now;
                Console.WriteLine("Test finished after {0} seconds.\n",
                    (endTime - startTime).TotalSeconds.ToString("F2"));
    
                startTime = DateTime.Now;
                Console.WriteLine("Starting test: Task.WhenAll...");
                var task = PerformTest_TaskWhenAll(workers, startTime);
                task.Wait();
                endTime = DateTime.Now;
                Console.WriteLine("Test finished after {0} seconds.\n",
                    (endTime - startTime).TotalSeconds.ToString("F2"));
    
                Console.ReadKey();
            }
    
            static void PerformTest_ParallelForEach(List<Worker> workers, DateTime testStart)
            {
                Parallel.ForEach(workers, worker => worker.DoWork(testStart).Wait());
            }
    
            static void PerformTest_TaskWaitAll(List<Worker> workers, DateTime testStart)
            {
                Task.WaitAll(workers.Select(worker => worker.DoWork(testStart)).ToArray());
            }
    
            static Task PerformTest_TaskWhenAll(List<Worker> workers, DateTime testStart)
            {
                return Task.WhenAll(workers.Select(worker => worker.DoWork(testStart)));
            }
        }
    }

    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                int numTasks = 20;
                var rng = new Random();
                using (var finishedSignal = new CountdownEvent(1))
                {
                    for (int i = 0; i < numTasks; ++i)
                    {
                        finishedSignal.AddCount();
                        Task.Factory.StartNew(() => task(rng.Next(2000, 5000), finishedSignal));
                    }
                    // We started with a count of 1 to prevent a race condition.
                    // Now we must decrement that count away by calling .Signal().
                    finishedSignal.Signal(); 
                    Console.WriteLine("Waiting for all tasks to complete...");
                    finishedSignal.Wait();
                }
                Console.WriteLine("Finished waiting for all tasks to complete.");
            }
            static void task(int sleepTime, CountdownEvent finishedSignal)
            {
                Console.WriteLine("Task sleeping for " + sleepTime);
                Thread.Sleep(sleepTime);
                finishedSignal.Signal();
            }
        }
    }

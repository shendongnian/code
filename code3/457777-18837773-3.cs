    class Program
    {
        static int s_numCurrentThreads = 0;
        static Random s_rnd = new Random();
        static void Main(string[] args)
        {
            int maxParallelTasks = 4;
            int totalTasks = 10;
            BlockingCounter blockingCounter = new BlockingCounter(maxParallelTasks);
            List<ManualResetEvent> waitList = new List<ManualResetEvent>();
            for (int i = 1; i <= totalTasks; i++)
            {
                
                ManualResetEvent finishEvent = new ManualResetEvent(false);
                waitList.Add(finishEvent);
                Console.WriteLine("Submitting task {0}",i);
                blockingCounter.WaitableIncrement();
                if (!ThreadPool.QueueUserWorkItem((obj) =>
                                                      {
                                                            try
                                                            {
                                                                ThreadProc(obj);
                                                            }
                                                            catch(Exception ex)
                                                            {
                                                                Console.Error.WriteLine("Task {0} failed: {1}", obj, ex.Message);
                                                            }
                                                            finally
                                                            {
                                                                // Exceptions are possible here too, 
                                                                // but proper error handling is not the goal of this sample
                                                                finishEvent.Set();
                                                                blockingCounter.WaitableDecrement();
                                                            }
                                                      }, i))
                {
                    waitList.Remove(finishEvent);
                    blockingCounter.WaitableDecrement();
                    Console.Error.WriteLine("Failed to submit task {0} for execution.", i);
                }
            }
            Console.WriteLine("Waiting for copmletion...");
            foreach (ManualResetEvent finishEvent in waitList)
            {
                finishEvent.WaitOne(10000); 
            }
            Console.WriteLine("Work done!");
            Console.ReadKey();
        }
        static void ThreadProc (object obj)
        {
            int taskNumber = (int) obj;
            int numThreads = Interlocked.Increment(ref s_numCurrentThreads);
            Console.WriteLine("Task {0} started. Total: {1}", taskNumber, numThreads);
            int sleepTime = s_rnd.Next(0, 5);
            Thread.Sleep(sleepTime * 1000);
            Console.WriteLine("Task {0} finished.", taskNumber);
            Interlocked.Decrement(ref s_numCurrentThreads);
        }

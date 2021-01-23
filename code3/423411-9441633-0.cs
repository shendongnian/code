       class Program
        {
            static object _ActiveWorkersLock = new object();
            static int _CountOfActiveWorkers;
     
            static void Go(object state)
            {
                try
                {
                    Console.WriteLine("Hello");
                }
                finally
                {
                    lock (_ActiveWorkersLock)
                    {
                        --_CountOfActiveWorkers;
                        Monitor.PulseAll(_ActiveWorkersLock);
                    }
                }
            }
    
            static void Main(string[] args)
            {
                for (int i = 0; i < 10; i++)
                {
                    lock (_ActiveWorkersLock)
                        ++_CountOfActiveWorkers;
                    ThreadPool.QueueUserWorkItem(Go);
                }
    
                lock (_ActiveWorkersLock)
                {
                    while (_CountOfActiveWorkers > 0)
                        Monitor.Wait(_ActiveWorkersLock);
                }
    
                Console.WriteLine("All done");
            }
        }

        private readonly Semaphore semLock = new Semaphore(0, 2);
        private readonly object _lockObject = new object();
        private int counter = 0;
        void MainMethod()
        {
            Thread t1 = new Thread(AMethodToBeRunByManyThreads);
            Thread t2 = new Thread(AMethodToBeRunByManyThreads);
            t1.Start();
            t2.Start();
            //  Now wait for them to finish
            semLock.WaitOne();
            semLock.WaitOne();
            lock (_lockObject)
            {
                // uses lock to enforce a memory barrier to ensure we read the right value of counter
                Console.WriteLine("done: {0}", counter);  
            }
        }
        void AMethodToBeRunByManyThreads()
        {
            lock (_lockObject) {
                counter++;
                Console.WriteLine("one");
                Thread.Sleep(1000);
            }
            semLock.Release();
        }

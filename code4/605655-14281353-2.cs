    public static class Foo
    {
        private static Type lockedType = null;
        private static object key = new object();
        private static ManualResetEvent signal = new ManualResetEvent(false);
        private static int threadsInMethodA = 0;
        private static Semaphore semaphore = new Semaphore(5, 5);//TODO set appropriate number of instances
    
        public void MethodA()
        {
            lock (key)
            {
                while (lockedType != this.GetType())
                {
                    if (lockedType == null)
                    {
                        lockedType = this.GetType();
                        //there may be other threads trying to get into the instance we just locked in
                        signal.Reset();
                    }
                    else if (lockedType != this.GetType())
                    {
                        signal.WaitOne();
                    }
    
                }
    
                Interlocked.Increment(ref threadsInMethodA);
                semaphore.WaitOne();
                        
            }
    
            try
            {
                MethodAImplementation();
            }
            finally
            {
                lock (key)
                {
                    semaphore.Release();
                    int threads = Interlocked.Decrement(ref threadsInMethodA);
                    if (threads == 0)
                    {
                        lockedType = null;
                        signal.Reset();
                    }
                }
            }
        }
    
        protected abstract void MethodAImplementation();
    }

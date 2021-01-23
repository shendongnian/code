    public static class Foo
    {
        private static Foo lockedInstance = null;
        private static object key = new object();
        private static ManualResetEvent signal = new ManualResetEvent(false);
        private static int threadsInMethodA = 0;
    
        public void MethodA()
        {
            lock (key)
            {
                while (lockedInstance != this)
                {
                    if (lockedInstance == null)
                    {
                        lockedInstance = this;
                        //there may be other threads trying to get into the instance we just locked in
                        signal.Reset();
                    }
                    else if (lockedInstance != this)
                    {
                        signal.WaitOne();
                    }
    
                }
    
                Interlocked.Increment(ref threadsInMethodA);
            }
    
            try
            {
                MethodAImplementation();
            }
            finally
            {
                lock (key)
                {
                    int threads = Interlocked.Decrement(ref threadsInMethodA);
                    if (threads == 0)
                    {
                        lockedInstance = null;
                        signal.Reset();
                    }
                }
            }
        }
    
        protected abstract void MethodAImplementation();
    }

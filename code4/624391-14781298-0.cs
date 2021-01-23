    public abstract class DisposableThread : IDisposable
    {
        private ManualResetEvent exiting = new ManualResetEvent(false);
        private Thread theThread;
        private  TimeSpan abortTimeout;
        public DisposableThread():
            this(TimeSpan.FromMilliseconds(100))
        {
        }
        public DisposableThread(TimeSpan abortTimeout)
        {
            this.abortTimeout = abortTimeout;
            theThread = new Thread((_) => ThreadProc());
        }
        protected virtual void ThreadProc()
        {
            while(!exiting.WaitOne(0))
            {
                WorkUnit(exiting);
            }
            ThreadCleanup();
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            exiting.Set();
            if (!theThread.Join(abortTimeout))
            {
                // logme -- the thread didn't shutdown gracefully
                theThread.Abort();
                while (!theThread.Join(1000))
                {
                    // logme -- the thread is doing something dumb in an exception handler
                }
            }
            exiting.Dispose();
        }
        // WorkUnit should return as quickly as safe if the exiting handle is set
        // If it doesn't the thread will be aborted if it takes longer than abortTimeout
        protected abstract void WorkUnit(WaitHandle exiting);
        // override if you need to cleanup on exit
        protected virtual void ThreadCleanup() { }
    }

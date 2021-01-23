        private readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);
        private readonly ManualResetEvent _threadStoppedEvent = new ManualResetEvent(false);
        private bool disposed;
        private int checkInterval = 10;//ms
     
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //managed
                }
                //unmanged
                _stopEvent.Set();
                _threadStoppedEvent.WaitOne();
            }
            disposed = true;
        }
        private void TheThread()
        {
            CreateSomeUnmangedResouces();
            while (!_stopEvent.WaitOne(checkInterval))
            { 
                DoStuffWithUnmangedResouces();   
            }
            DestroySomeUnmangedResouces();
            _threadStoppedEvent.Set();
        }

    var waitHandle = new AutoResetEvent(initialState: false);
    ThreadPool.QueueUserWorkItem(state =>
    {
        lock(this.staticLock)
        {
            try
            {
                // Do something ...
            }
            finally
            {
                waitHandle.Set();
            }
            // Do something else...
        }
    }
    waitHandle.WaitOne();

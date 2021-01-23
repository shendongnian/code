    lock(this.StaticLock)
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            lock(this.StaticLock)
            {
                 // Do something ...
 
                 Monitor.Pulse(this.StaticLock);
                 // Do something else...
            }
        });
        Monitor.Wait(this.StaticLock);
    }

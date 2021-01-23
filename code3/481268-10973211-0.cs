    public void Lock()
    {
        this._lock.AcquireWrite();
    }
    
    internal virtual void AcquireWrite()
    {
        lock (this)
        {
            while (this._lock != 0)
            {
                try
                {
                    Monitor.Wait(this);
                    continue;
                }
                catch (ThreadInterruptedException)
                {
                    continue;
                }
            }
            this._lock = -1;
        }
    }
    
     

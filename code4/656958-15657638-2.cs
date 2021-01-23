    void RunLoop()
    {
        
        for (;;)
        {
            // do work here...
            lock (syncPrimitive)
            {
                Monitor.Wait(syncPrimitive);
            }
        }
    }

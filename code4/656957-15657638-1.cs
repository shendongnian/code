    void RunLoop()
    {
        lock (syncPrimitive)
        {
            for (;;)
            {
                // do work here...
                Monitor.Wait(syncPrimitive);
            }
        }
    }

    void Notify()
    {
        lock (syncPrimitive)
        {
            Monitor.Pulse(syncPrimitive);
        }
    }

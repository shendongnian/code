    void Notify()
    {
        lock (syncPrimitive)
        {
            Monitor.Pulese(syncPrimitive);
        }
    }

    private readonly object syncLock = new object();
    public bool WaitUntilFull(int timeout) {
        if(CollectionIsFull) return true; // I'm assuming we can call this safely
        lock(syncLock) {
            if(CollectionIsFull) return true;
            return Monitor.WaitOne(syncLock, timeout);
        }
    }

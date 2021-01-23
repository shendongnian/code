    if(CollectionIsFull) {
        lock(syncLock) {
            if(CollectionIsFull) { // double-check with the lock
                Monitor.PulseAll(syncLock);
            }
        }
    }

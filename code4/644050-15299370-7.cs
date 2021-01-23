    Monitor.Enter(lockObject); // acquires the lock
    tuplesToAdd.Add(tuple);
    if (tuplesToAdd.Count == 100000)
    {
        var tuplesToPush = tuplesToAdd;
        tuplesToAdd = new List<tuple>(10000);
        Monitor.Exit(lockObject);  // releases the lock so other threads can process
        lock (pushLock)  // prevent multiple threads from pushing at the same time
        {
            inspace_.PutAll(tuplesToPush);
        }
    }
    else
    {
        Monitor.Exit(lockObject);
    }

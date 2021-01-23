    public T[] WaitForItemAndDequeue(TimeSpan timeout)
    {
        lock (syncObj) {
            if (queue.Count == 0 && !Monitor.Wait(syncObj, timeout)) {
                return null; // Timeout expired
            }
            return Dequeue();
        }
    }
    public T[] WaitForItem()
    {
        lock (syncObj) {
            while (queue.Count != 0) {
                Monitor.Wait(syncObj);
            }
            return Dequeue();
        }
    }

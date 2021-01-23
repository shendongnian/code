    private readonly object _queueLock = new object();
    private readonly object _processLock = new object();
    void SequenceAction(Action action)
    {
        lock (_queueLock)
        {
            _RaiseEventQueue.Enqueue(action);
        }
        if (Monitor.TryEnter(_processLock))
        {
            while (true)
            {
                Action a;
                lock (_queueLock)
                {
                    if (_RaiseEventQueue.Count == 0) return;
                    a = _RaiseEventQueue.Dequeue();
                }
                a();
            }
            Monitor.Exit(_processLock);
        }
    }

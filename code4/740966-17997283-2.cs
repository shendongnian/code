    object TimerLock = new object();
    void TimerCallback(object o)
    {
        if (!Monitor.TryEnter(TimerLock))
        {
            // already in timer. Exit.
            return;
        }
        // do stuff
        // then release the lock
        Monitor.Exit(TimerLock);
    }

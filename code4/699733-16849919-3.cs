    void TimerProc(object state)
    {
        if (!Monitor.TryEnter(timerLock))
        {
            // a request is currently being processed
            return;
        }
        try
        {
            // do request here
        }
        catch (expected exceptions)
        {
        }
        Monitor.Exit(timerLock);
    }

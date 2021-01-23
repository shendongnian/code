    private object timerLock = new object();
    timer_ticked()
    {
        if (!Monitor.TryEnter(timerLock))
            return;
        try
        {
            // do stuff here
        }
        finally
        {
            Monitor.Exit(timerLock);
        }
    }

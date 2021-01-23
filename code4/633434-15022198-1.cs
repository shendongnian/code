    bool gotMonitor = false;
    try
    {
        gotMonitor = Monitor.TryEnter(monitor, 500);
        if (gotMonitor)
        {
            // Okay, we're in the lock. We can do something useful now.
        }
        else
        {
            // Timed out - do something else
        }
    }
    finally
    {
        if (gotMonitor)
        {
            Monitor.Exit(monitor);
        }
    }

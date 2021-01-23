    bool gotMonitor = false;
    try
    {
        Monitor.TryEntry(monitor, 500, ref gotMonitor);
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

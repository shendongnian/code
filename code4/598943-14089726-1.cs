    bool gotMonitor = false;
    try
    {
        Monitor.TryEnter(obj, ref gotMonitor);
        if (!gotMonitor)
        {
            throw new Exception(...);
        }
        // Presumably other code
    }
    finally
    {
        if (gotMonitor)
        {
            Monitor.Exit(obj);
        }
    }

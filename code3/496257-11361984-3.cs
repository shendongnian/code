    Monitor.Enter(_syncRoot)
    try
    {
        // Do stuff
    }
    finally
    {
        Monitor.Exit(_syncRoot);
    }

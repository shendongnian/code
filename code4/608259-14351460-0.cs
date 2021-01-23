    private static object lockObject = new Object();
    private static void convert(object source, FileSystemEventArgs f)
    {
        if (!Monitor.TryEnter(lockObject))
        {
            // unable to get lock, return.
            return;
        }
        try
        {
            // do stuff here
        }
        finally
        {
            Monitor.Exit(lockObject);
        }

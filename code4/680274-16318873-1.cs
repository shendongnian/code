    if (Monitor.TryEnter(_lockObject))
    {
        try
        {
            // Do protected work
        }
        finally
        {
            Monitor.Exit(_lockObject);
        }
     }

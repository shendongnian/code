    try
    {
        Monitor.Enter(object);
    }
    finally
    {
        Monitor.Exit(object);
    }

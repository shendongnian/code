    if (!Monitor.TryEnter(obj, 2000))
    {
        throw new Exception(...);
    }
    try
    {
        // Presumably other code
    }
    finally
    {
         Monitor.Exit(obj);
    }

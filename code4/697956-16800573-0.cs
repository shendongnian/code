    bool entered = !Monitor.TryEnter(someLockObject);
    try
    {
        if (!entered)
            throw Exception("Multi-thread call!");
        // Actual code
    }
    finally
    {
        if (entered)
        {
            Monitor.Exit(someLockObject);
        }
    }

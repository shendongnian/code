    Monitor.Enter(lockObject)
    // see next paragraph
    try
    {
        // code that was in the lock block
    }
    finally
    {
       Monitor.Exit(lockObject);
    }

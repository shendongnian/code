    while (true)
    {
        try
        {
            lockObject.EnterReadLock();
            //Do stuff
        }
        finally
        {
            lockObject.ExitReadLock();
        }
    }

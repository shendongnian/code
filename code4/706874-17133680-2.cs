    try
    {
        SyncObj.EnterReadLock();
        return ComplexGetterMethod();
    }
    finally
    {
        if (SyncObj.IsReadLockHeld)
            SyncObj.ExitReadLock();
    }

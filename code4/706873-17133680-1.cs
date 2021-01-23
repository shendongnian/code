    SyncObj.EnterReadLock();
    try
    {
        return ComplexGetterMethod();
    }
    finally
    {
        SyncObj.ExitReadLock();
    }

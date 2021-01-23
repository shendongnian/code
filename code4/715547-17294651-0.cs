    ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();
    ...
    rwls.EnterReadLock();
    try
    {
        // some enumeration
    }
    finally
    {
        rwls.ExitReadLock();
    }
    ...
    rwls.EnterWriteLock();
    try
    {
        // some bulk update
    }
    finally
    {
        rwls.ExitWriteLock();
    }

    private static ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
    
    public static void LoadData()
    {
        _cacheLock.EnterWriteLock();
        try
        {
            // Load data from the database
        }
        finally
        {
            _cacheLock.ExitWriteLock();
        }
    }
    
    public static string ReadData(Guid key)
    {
        _cacheLock.EnterReadLock();
        try
        {
            // Lookup key in data and return value
        }
        finally
        {
            _cacheLock.ExitReadLock();
        }
    }

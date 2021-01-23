    private ReaderWriterLockSlim tableLock = new ReaderWriterLockSlim();
    public bool Search(string s)
    {
        tableLock.EnterReadLock();
        try
        {
            // do the search here
            return result;
        }
        finally
        {
            tableLock.ExitReadLock();
        }
    }

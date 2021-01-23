    public void Modify(string s)
    {
        tableLock.EnterWriteLock();
        try
        {
            // do the modification here
            return;
        }
        finally
        {
            tableLock.ExitWriteLock();
        }
    }

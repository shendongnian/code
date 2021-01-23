    public void WithReaderLocksForItemsNamed(string[] itemNames, Action action)
    {
        // this gets locks for the items specified from my internation dictionary
        ReaderWriterLockSlim[ ] locks = LocksForItemsNamed( itemNames ) ;
        try
        {
            foreach( var @lock in locks )
            {
                @lock.EnterReadLock( ) ;
            }
            action( ) ;
        }
        finally
        {
            foreach( var @lock in locks.Reverse() )
            {
                if (@lock.IsReadLockHeld)
                {
                    @lock.ExitReadLock( ) ;
                }
            }
        }
    }

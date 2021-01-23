    private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
    
    public void ReadOp()
    {
         rwLock.EnterReadLock();  //only blocks if write lock held
         try
         {
             //do read op
         }
         finally
         {
             _rwLock.ExitReadLock();
         }
    }
    
    public void ReadOp()
    {
         rwLock.EnterWriteLock();  //blocks until no read or write locks held
         try
         {
             //do write op
         }
         finally
         {
             _rwLock.ExitWriteLock();
         }
    }

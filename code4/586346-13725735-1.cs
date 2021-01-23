    public int Something
    {
       get {
          locker.EnterReadLock();
    
          try {
             return something;
          } finally {
             locker.ExitReadLock();
          }
       }
       set {
          locker.EnterWriteLock();
    
          try {
             something = value;
          } finally {
             locker.ExitWriteLock();
          }
       }
    }

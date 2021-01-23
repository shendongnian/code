    class MyConcurrentList<T>
    {
        private List<T> _theList = new List<T>();
        private ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();
        public Update()
        {
            _rwLock.EnterWriteLock();        
            try
            {
                // do the update
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
        public T GetItem(int ix)
        {
            _rwLock.EnterReadLock();        
            try
            {
                // get the item
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }
    }

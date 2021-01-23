    class MyThreadSafeList<T>
    {
        private readonly List<T> internalList = new List<T>();
        private readonly ReaderWriterLockSlim lockSlim = new ReaderWriterLockSlim();
    
        public void EnterReadLock()
        {
            lockSlim.EnterReadLock();
        }
    
        public void ExitReadLock()
        {
            lockSlim.ExitReadLock();
        }
    
        public void EnterWriteLock()
        {
            lockSlim.EnterWriteLock();
        }
    
        public void ExitWriteLock()
        {
            lockSlim.ExitWriteLock();
        }
    
        public void Add(T item)
        {
            if (!lockSlim.IsWriteLockHeld)
            {
                throw new InvalidOperationException();
            }
    
            internalList.Add(item);
        }
    
        public void Remove(T item)
        {
            if (!lockSlim.IsWriteLockHeld)
            {
                throw new InvalidOperationException();
            }
    
            internalList.Remove(item);
        }
    
        public T this[int index]
        {
            get
            {
                if (!lockSlim.IsReadLockHeld)
                {
                    throw new InvalidOperationException();
                }
    
                return internalList[index];
            }
            set
            {
                if (!lockSlim.IsWriteLockHeld)
                {
                    throw new InvalidOperationException();
                }
    
                internalList[index] = value;
            }
        }
    }

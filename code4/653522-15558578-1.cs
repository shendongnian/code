    public class ConcurrentList<T>: IList<T>
    {
        private readonly List<T> _theList;
        private readonly ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();
        public ConcurrentList()
        {
            _theList = new List<T>();
        }
        public ConcurrentList(IEnumerable<T> collection)
        {
            _theList = new List<T>(collection);
        }
        public ConcurrentList(int size)
        {
            _theList = new List<T>(size);
        }
        public int IndexOf(T item)
        {
            _rwlock.EnterReadLock();
            try
            {
                return _theList.IndexOf(item);
            }
            finally
            {
                _rwlock.ExitReadLock();
            }
        }
        public void Insert(int index, T item)
        {
            _rwlock.EnterWriteLock();
            try
            {
                _theList.Insert(index, item);
            }
            finally
            {
                _rwlock.ExitWriteLock();
            }
        }
        public T this[int index]
        {
            get
            {
                _rwlock.EnterReadLock();
                try
                {
                    return _theList[index];
                }
                finally
                {
                    _rwlock.ExitReadLock();
                }
            }
            set
            {
                _rwlock.EnterWriteLock();
                try
                {
                    _theList[index] = value;
                }
                finally
                {
                    _rwlock.ExitWriteLock();
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            _rwlock.EnterReadLock();
            try
            {
                foreach (var item in _theList)
                {
                    yield return item;
                }
            }
            finally
            {
                _rwlock.ExitReadLock();
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        // other methods not implemented, for brevity
    }

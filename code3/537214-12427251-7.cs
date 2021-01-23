    public static IEnumerable<T> SingleEnumeration<T>(this IEnumerable<T> source)
    {
        return new SingleEnumerator<T>(source);
    }
    private class SingleEnumerator<T> : IEnumerable<T>
    {
        private CacheEntry<T> cacheEntry;
        public SingleEnumerator(IEnumerable<T> sequence)
        {
            cacheEntry = new CacheEntry<T>();
            cacheEntry.Sequence = sequence.GetEnumerator();
            cacheEntry.CachedValues = new List<T>();
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (cacheEntry.FullyPopulated)
            {
                return cacheEntry.CachedValues.GetEnumerator();
            }
            else
            {
                return iterateSequence<T>(cacheEntry).GetEnumerator();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    private static IEnumerable<T> iterateSequence<T>(CacheEntry<T> entry)
    {
        for (int i = 0; entry.ensureItemAt(i); i++)
        {
            yield return entry[i];
        }
    }
    private class CacheEntry<T>
    {
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        public bool FullyPopulated { get; private set; }
        public IEnumerator<T> Sequence { get; set; }
        //storing it as object, but the underlying objects will be lists of various generic types.
        public List<T> CachedValues { get; set; }
        public T this[int index]
        {
            get
            {
                try
                {
                    cacheLock.EnterReadLock();
                    return CachedValues[index];
                }
                finally
                {
                    cacheLock.ExitReadLock();
                }
            }
        }
        private static object key = new object();
        /// <summary>
        /// Ensure that the cache has an item a the provided index.  If not, take an item from the 
        /// input sequence and move to the cache.
        /// 
        /// The method is thread safe.
        /// </summary>
        /// <returns>True if the cache already had enough items or 
        /// an item was moved to the cache, 
        /// false if there were no more items in the sequence.</returns>
        public bool ensureItemAt(int index)
        {
            //if the cache already has the items we don't need to lock to know we 
            //can get it
            if (index < CachedValues.Count)
                return true;
            //if we're done there's no race conditions hwere either
            if (FullyPopulated)
                return false;
            lock (key)
            {
                //re-check the early-exit conditions in case they changed while we were
                //waiting on the lock.
                //we already have the cached item
                if (index < CachedValues.Count)
                    return true;
                //we don't have the cached item and there are no uncached items
                if (FullyPopulated)
                    return false;
                //we actually need to get the next item from the sequence.
                if (Sequence.MoveNext())
                {
                    try
                    {
                        cacheLock.EnterWriteLock();
                        CachedValues.Add(Sequence.Current);
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                    return true;
                }
                else
                {
                    FullyPopulated = true;
                    return false;
                }
            }
        }
    }

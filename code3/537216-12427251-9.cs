    public static IEnumerable<T> SingleEnumeration<T>(this IEnumerable<T> source)
    {
        return new SingleEnumerator<T>(source);
    }
    private class SingleEnumerator<T> : IEnumerable<T>
    {
        private CacheEntry<T> cacheEntry;
        public SingleEnumerator(IEnumerable<T> sequence)
        {
            cacheEntry = new CacheEntry<T>(sequence.GetEnumerator());
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
        using (var iterator = entry.CachedValues.GetEnumerator())
        {
            int i = 0;
            while (entry.ensureItemAt(i) && iterator.MoveNext())
            {
                yield return iterator.Current;
                i++;
            }
        }
    }
    private class CacheEntry<T>
    {
        public bool FullyPopulated { get; private set; }
        public ConcurrentQueue<T> CachedValues { get; private set; }
        private static object key = new object();
        private IEnumerator<T> sequence;
        public CacheEntry(IEnumerator<T> sequence)
        {
            this.sequence = sequence;
            CachedValues = new ConcurrentQueue<T>();
        }
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
                if (sequence.MoveNext())
                {
                    CachedValues.Enqueue(sequence.Current);
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

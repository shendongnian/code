    public class AtomicList<T> : IEnumerable<T>
    {
        private List<T> internalCollection = new List<T>();
    
        public void Add(T vlue)
        {
            List<T> update = new List<T>(internalCollection);
            update.Add(value);
            Interlocked.Exchange(ref internalCollection, update);
        }
    
        public bool Remove(T value)
        {
            List<T> update = new List<T>(internalCollection);
            bool removed = update.Remove(value);
            if (removed) Interlocked.Exchange(ref internalCollection, update);
            return removed;
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            ...

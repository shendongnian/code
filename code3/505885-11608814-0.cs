    public class CacheList<T, TKey>
    {
        private readonly Dictionary<TKey, T> _cacheItems = new Dictionary<TKey, T>();
        private readonly Func<T, TKey> selector;
        public CacheList(Func<T, TKey> selector)
        {
            this.selector = selector;
        }
        public IList<T> GetItems()
        {
            return new List<T>(_cacheItems.Values);
        }
    
        public bool Add(T item)
        {
            TKey key = selector(item);
    
            if (_cacheItems.ContainsKey(key)) { return false; }
            
            _cacheItems.Add(key, item);
            return true;
        }
        public bool TryGetValue(TKey key, out T value)
        {
            return _cacheItems.TryGetValue(key, out value);
        }
    }

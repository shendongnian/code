    public class Cache<T>: IEnumerable<T>
    {
        //Dictionary to hold the values of the cache
        private Dictionary<string, T> m_cacheStore = new Dictionary<string, T>();
        //Dictionary to hold the number of times each key has been accessed
        private Dictionary<string, int> m_cacheAccessCount = new Dictionary<string, int>(); 
        public T Get(string cacheKey)
        {
            if (m_cacheStore.ContainsKey(cacheKey))
            {
                //Increment access counter
                if (!m_cacheAccessCount.ContainsKey(cacheKey))
                    m_cacheAccessCount.Add(cacheKey, 0);
                m_cacheAccessCount[cacheKey] = m_cacheAccessCount[cacheKey] + 1;
                return m_cacheStore[cacheKey];
            }
            throw new KeyNotFoundException(cacheKey);
        }
        public void Add(string cacheKey, T cacheValue)
        {
            if(m_cacheStore.ContainsKey(cacheKey))
                throw new ArgumentException(string.Format("An element with the key {0} already exists in the cache", cacheKey));
            m_cacheStore.Add(cacheKey, cacheValue);
        }
        #region Implementation of IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var source in m_cacheAccessCount.OrderBy(kvp => kvp.Value))
            {
                yield return m_cacheStore[source.Key];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }

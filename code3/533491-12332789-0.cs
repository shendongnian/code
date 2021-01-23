    public class OrderedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private Dictionary<TKey, TValue> m_dictionary;
        private List<TValue> m_list = new List<TValue>();
        private object m_syncRoot = new object();
        public OrderedDictionary()
        {
            m_dictionary = new Dictionary<TKey, TValue>();
        }
        public OrderedDictionary(IEqualityComparer<TKey> comparer)
        {
            m_dictionary = new Dictionary<TKey, TValue>(comparer);
        }
        public void Add(TKey key, TValue value)
        {
            lock (m_syncRoot)
            {
                m_dictionary.Add(key, value);
                m_list.Add(value);
            }
        }
        public TValue this[int index]
        {
            get { return m_list[index]; }
        }
        public TValue this[TKey key]
        {
            get { return m_dictionary[key]; }
        }
        public int Count 
        {
            get { return m_dictionary.Count; } 
        }
        public Dictionary<TKey, TValue>.KeyCollection Keys 
        {
            get { return m_dictionary.Keys; } 
        }
        public Dictionary<TKey, TValue>.ValueCollection Values 
        {
            get { return m_dictionary.Values; } 
        }
        public void Clear()
        {
            lock (m_syncRoot)
            {
                m_dictionary.Clear();
                m_list.Clear();
            }
        }
        public bool ContainsKey(TKey key)
        {
            return m_dictionary.ContainsKey(key);
        }
        public bool ContainsValue(TValue value)
        {
            return m_dictionary.ContainsValue(value);
        }
        public void Insert(int index, TKey key, TValue value)
        {
            lock (m_syncRoot)
            {
                m_list.Insert(index, value);
                m_dictionary.Add(key, value);
            }
        }
        public void Remove(TKey key)
        {
            lock (m_syncRoot)
            {
                if (ContainsKey(key))
                {
                    var existing = m_dictionary[key];
                    m_list.Remove(existing);
                    m_dictionary.Remove(key);
                }
            }
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return m_dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

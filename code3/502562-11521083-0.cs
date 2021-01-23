    class TDictionary<K, V>
    {
        struct KeyValuePair
        {
            public K Key;
            public V Value;
        }
        private readonly List<KeyValuePair> fList = new List<KeyValuePair>();
        public void Add(K key, V value)
        {
            fList.Add(new KeyValuePair { Key = key, Value = value });
        }
        public List<V> this[K key]
        {
            get { return (from pair in fList where pair.Key.Equals(key) select pair.Value).ToList(); }
        }
        public List<K> Keys
        {
            get { return fList.Select(pair => pair.Key).ToList(); }
        }
        public List<V> Values
        {
            get { return fList.Select(pair => pair.Value).ToList(); }
        }
    }

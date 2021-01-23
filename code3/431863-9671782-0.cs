    class MyCache<K, V> : IDictionary<K, V>
    {
        private class MyValue
        {
            public readonly V Value;
            public readonly DateTime InsertionTime;
        }
    
        private IDictionary<K, MyValue> m_dict;
        public MyCache(IDictionaryFactory dictionaryFactory)
        {
            m_dict = dictionaryFactory.CreateDictionary<K, MyValue>();
        }
        ...
    }

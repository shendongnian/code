    class TripleKeyDictionnary<TKey1, TKey2, TKey3>
    {
        public Tuple<TKey2, TKey3> this[TKey1 key]
        {
            get
            {
                return _key1Lookup[key];
            }
        }
        public Tuple<TKey1, TKey3> this[TKey2 key]
        {
            get
            {
                return _key2Lookup[key];
            }
        }
        public Tuple<TKey1, TKey2> this[TKey3 key]
        {
            get
            {
                return _key3Lookup[key];
            }
        }
        private Dictionary<TKey1, Tuple<TKey2, TKey3>> _key1Lookup = new Dictionary<TKey1, Tuple<TKey2, TKey3>>();
        private Dictionary<TKey2, Tuple<TKey1, TKey3>> _key2Lookup = new Dictionary<TKey2, Tuple<TKey1, TKey3>>();
        private Dictionary<TKey3, Tuple<TKey1, TKey2>> _key3Lookup = new Dictionary<TKey3, Tuple<TKey1, TKey2>>();
        public void Add(TKey1 key1, TKey2 key2, TKey3 key3)
        {
            _key1Lookup.Add(key1, Tuple.Create(key2, key3));
            _key2Lookup.Add(key2, Tuple.Create(key1, key3));
            _key3Lookup.Add(key3, Tuple.Create(key1, key2));
        }
    }

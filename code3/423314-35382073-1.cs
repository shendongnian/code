    internal class BiDictionary<TKey1, TKey2> : DynamicObject, IEnumerable<KeyPair<TKey1, TKey2>>
    {
        private readonly Dictionary<TKey1, TKey2> _K1K2 = new Dictionary<TKey1, TKey2>();
        private readonly Dictionary<TKey2, TKey1> _K2K1 = new Dictionary<TKey2, TKey1>();
        private readonly string _key1Name;
        private readonly string _key2Name;
        public BiDictionary(string key1Name, string key2Name)
        {
            _key1Name = key1Name;
            _key2Name = key2Name;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name == _key1Name)
            {
                result = _K1K2;
                return true;
            }
            if (binder.Name == _key2Name)
            {
                result = _K2K1;
                return true;
            }
            result = null;
            return false;
        }
        public void Add(TKey1 key1, TKey2 key2)
        { 
            _K1K2.Add(key1, key2);
            _K2K1.Add(key2, key1);
        }
        public IEnumerator<KeyPair<TKey1, TKey2>> GetEnumerator()
        {
            return _K1K2.Zip(_K2K1, (d1, d2) => new KeyPair<TKey1, TKey2>
            {
                Key1 = d1.Key,
                Key2 = d2.Key
            }).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

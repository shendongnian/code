    public class FastLookupBindingList<TKey, TVal> : BindingList<TVal>
    {
        private readonly IDictionary<TKey, TVal> _dict = new Dictionary<TKey, TVal>();
        private readonly Func<TVal, TKey> _keyFunc;
        public FastLookupBindingList(Func<TVal, TKey> keyFunc)
        {
            _keyFunc = keyFunc;
        }
        public FastLookupBindingList(Func<TVal, TKey> keyFunc, IList<TVal> sourceList) : base(sourceList)
        {
            _keyFunc = keyFunc;
            foreach (var item in sourceList)
            {
                var key = _keyFunc(item);
                _dict.Add(key, item);
            }
        }
        public TVal FastFind(TKey key)
        {
            TVal val;
            _dict.TryGetValue(key, out val);
            return val;
        }
        protected override void InsertItem(int index, TVal val)
        {
            _dict.Add(_keyFunc(val), val);
            base.InsertItem(index, val);
        }
        protected override void SetItem(int index, TVal val)
        {
            var key = _keyFunc(val);
            _dict[key] = val;
            base.SetItem(index, val);
        }
        protected override void RemoveItem(int index)
        {
            var item = this[index];
            var key = _keyFunc(item);
            _dict.Remove(key);
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            _dict.Clear();
            base.ClearItems();
        }
    }

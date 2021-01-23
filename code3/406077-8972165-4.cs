     public class MyDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        readonly Func<TKey, TValue> _activator;
        public MyDictionary(Func<TKey, TValue> activator)
        {
            _activator = activator;
        }
        public new TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!TryGetValue(key, out value))
                {
                    value = _activator(key);
                    Add(key, value);
                }
                return value;
            }
            set { base[key] = value; }
        } 
    }

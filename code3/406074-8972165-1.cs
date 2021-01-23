        public class MyDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!TryGetValue(key, out value))
                {
                    value = Activator.CreateInstance<TValue>();
                    Add(key, value);
                }
                return value;
            }
            set { base[key] = value; }
        } 
    }

    public class PassthruDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> instance;
        // ... other stuff
        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (instance.TryGetValue(key, out value))
                {
                    return value;
                }
                else
                {
                    return default(TValue);
                }
            }
            // ... more
        }
    }

     public class SafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly object _Padlock = new object();
        private readonly Dictionary<TKey, TValue> _Dictionary = new Dictionary<TKey, TValue>();
        public TValue this[TKey key]
        {
            get
            {
                lock (_Padlock)
                {
                    return _Dictionary[key];
                }
            }
            set
            {
                lock (_Padlock)
                {
                    _Dictionary[key] = value;
                }
            }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (_Padlock)
                return _Dictionary.TryGetValue(key, out value);
        }
    public bool TryAdd(TKey key, TValue value)
    {
        lock (_Padlock)
        {
            if (!_Dictionary.ContainsKey(key))
            {
                _Dictionary.Add(key, value);
                return true;
            }
            return false;
            }
      }
    
    public bool TryRemove(TKey key)
    {
        lock (_Padlock)
        {
            return _dictionary.Remove(key);
        }
    }
    }
        internal void Add(TKey key, TValue val)
        {
            lock (_Padlock)
            {
                _Dictionary.Add(key, val);
            }
        }
        public bool ContainsKey(TKey id)
        {
            lock (_Padlock)
                return _Dictionary.ContainsKey(id);
        }
        public List<KeyValuePair<TKey, TValue>> OrderBy(Func<KeyValuePair<TKey, TValue>, TKey> func)
        {
            lock (_Padlock)
                return _Dictionary.OrderBy(func).ToList();
        }
        public Dictionary<TKey, TValue>.ValueCollection Values
        {
            get
            {
                lock (_Padlock)
                    return _Dictionary.Values;
            }
        }
        public Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get
            {
                lock (_Padlock)
                    return _Dictionary.Keys;
            }
        }
        
        
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            lock (_Padlock)
                return _Dictionary.GetEnumerator();
        
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (_Padlock)
                return _Dictionary.GetEnumerator();
            
        }
    }

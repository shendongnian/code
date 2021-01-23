    class GenericDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> dictionary = new Dictionary<TKey,TValue>();
    
        public void AddToGenericDictionary(TKey key, TValue value)
        {
            dictionary.Add(key, value);
        }
    }

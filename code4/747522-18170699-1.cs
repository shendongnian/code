    class GenericDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public void AddToGenericDictionary(TKey key, TValue value)
        {
            this.Add(key, value);
        }
    }

    public static class Extensions
    { 
        public static TValue GetValueOrDefault<TKey, TValue>(
                this IDictionary<Tkey, TValue> iDictionary, Tkey key)
        {
            TValue result;
            return iDictionary.TryGetValue(key, out result) ? result : default(TValue)
        }
    }

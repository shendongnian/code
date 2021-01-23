    public static class DictionaryExtensions 
    {
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue fallback = default(TValue))
        {
            TValue result;
            return dictionary.TryGetValue(key, out result) ? result : fallback;
        }
    }

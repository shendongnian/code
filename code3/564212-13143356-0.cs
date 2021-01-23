    public static class IDictionaryExtensions
    {
        public static TValue ValueAtOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary == null || !dictionary.ContainsKey(key))
            {
                return defaultValue;
            }
            return dictionary[key];
        }
    }

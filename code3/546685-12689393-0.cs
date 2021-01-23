    public static class Utility
    {
        public static TValue GetValueOrDefault<TKey,TValue>(
            this Dictionary<TKey, TValue> dictionary, 
            TKey key, 
            TValue @default = default(TValue))
        {
            TValue value;
            return dictionary.TryGetValue(key, out value)
                       ? value
                       : @default;
        }
    }

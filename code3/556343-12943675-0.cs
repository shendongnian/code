    public static class DictionaryUtilities
    {
        public static TValue SafeGet<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultIfNotFound = default(TValue))
        {
            TValue value;
            return dict.TryGetValue(key, out value) ? value : defaultIfNotFound;
        }
    }

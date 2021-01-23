    public static class MyExtensions
    {
        public static void AddIfNotNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if ((object)value != null)
                dictionary.Add(key, value);
        }
    }

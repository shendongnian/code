    public static class ReadOnlyDictionary
    {
        public static IReadOnlyDictionary<TKey, TValue> Empty<TKey, TValue>()
            => EmptyReadOnlyDictionary<TKey, TValue>.Instance;
    }

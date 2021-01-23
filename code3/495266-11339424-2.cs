    private class KeyEqualityComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<T, TKey> _keySelector;
        public KeyEqualityComparer(Func<T, TKey> keySelector)
        { _keySelector = keySelector; }
        public int GetHashCode(T item)
        { return _keySelector(item).GetHashCode(); }
        public bool Equals(T x, T y)
        { return EqualityComparer<TKey>.Default.Equals(_keySelector(x), _keySelector(y)); }
    }
    public static IEnumerable<T> ExceptBy<T, TKey>(
        this IEnumerable<T> first, 
        IEnumerable<T> second, 
        Func<T, TKey> keySelector
    )
    {
        return first.Except(second, new KeyEqualityComparer<T, TKey>(keySelector));
    }

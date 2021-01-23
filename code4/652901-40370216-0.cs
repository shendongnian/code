    public static IEnumerable<T> Except<T, TKey>(this IEnumerable<TKey> items,
        IEnumerable<T> other, Func<T, TKey> getKey) {
        return from item in items
            where !other.Contains(getKey(item))
            select item;
    }

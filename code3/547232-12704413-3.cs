    public static class EnumerableExt
    {
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TKey, TKey, bool> equalityComparison)
        {
            return source.GroupBy(
                keySelector,
                DelegateEqualityComparer<TKey>.Create(equalityComparison);
        }
    }

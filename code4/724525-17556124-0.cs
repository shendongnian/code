    public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector, IComparer<TKey> comparer = null)
    {
        comparer = comparer ?? Comparer<TKey>.Default;
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                throw new ArgumentException("Source must have at least one item");
            var maxItem = iterator.Current;
            var maxKey = keySelector(maxItem);
            while (iterator.MoveNext())
            {
                var nextKey = keySelector(iterator.Current);
                if (comparer.Compare(nextKey, maxKey) > 0)
                {
                    maxItem = iterator.Current;
                    maxKey = nextKey;
                }
            }
            return maxItem;
        }
    }

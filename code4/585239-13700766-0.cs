        private static IEnumerable<TSource> ExceptByImpl<TSource, TKey>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer)
        {
        #if !NO_HASHSET
        HashSet<TKey> keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);
        foreach (var element in first)
        {
            TKey key = keySelector(element);
            if (keys.Contains(key))
            {
                continue;
            }
            yield return element;
            keys.Add(key);
        }
        #else
        var keys = second.ToDictionary(keySelector, keyComparer);
        foreach (var element in first)
        {
            TKey key = keySelector(element);
            if (keys.ContainsKey(key))
            {
                continue;
            }
            yield return element;
            keys.Add(key, element);
        }
        #endif
    }

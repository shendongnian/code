    public IEnumerable<TSource> NextTwoStrictlyIncreasing<TSource>(IEnumerable<TSource> source,
        Func<TSource, TSource, bool> isStrictlyIncreasing)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
                yield break;
            var twoBack = iterator.Current;
                
            if (!iterator.MoveNext())
                yield break;
            var oneBack = iterator.Current;
            while (iterator.MoveNext())
            {
                if (isStrictlyIncreasing(oneBack, iterator.Current)
                    && isStrictlyIncreasing(twoBack, oneBack))
                {
                    yield return twoBack;
                    yield return oneBack;
                    yield return iterator.Current;
                    while (iterator.MoveNext())
                        yield return iterator.Current;
                    yield break;
                }
                twoBack = oneBack;
                oneBack = iterator.Current;
            }
        }
    }

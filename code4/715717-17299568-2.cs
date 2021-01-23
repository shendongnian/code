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
            bool previousIsIncreasing = false;
            bool isIncreasing = false;
            while (iterator.MoveNext())
            {
                isIncreasing = isStrictlyIncreasing(oneBack, iterator.Current);
                if (isIncreasing && previousIsIncreasing)
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
                previousIsIncreasing = isIncreasing;
            }
        }
    }

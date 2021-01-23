    public static IEnumerable<TSource> WhereWithPrevious<TSource>
    (this IEnumerable<TSource> source,
     Func<TSource, TSource, bool> selector)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                 yield break;
            }
            TSource previous = default(TSource);
           
            // return the first item always
            yield return iterator.Current;
        
            while (iterator.MoveNext())
            {
                if(previous != null && selector(previous, iterator.Current))
                {
                    yield return iterator.Current;
                }
                previous = iterator.Current;
            }
        }
    }

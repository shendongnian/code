    public static TSource MaxBy<TSource,TValue>(
        this IEnumerable<TSource> source,
        Func<TSource,TValue> selector)
    {
        using(var iter = source.GetEnumerator())
        {
            if (!iter.MoveNext())
                throw new InvalidOperationException("Empty sequence");
            var max = selector(iter.Current);
            var item = iter.Current;
            var comparer = Comparer<TValue>.Default;
            while(iter.MoveNext())
            {
                var tmp = selector(iter.Current);
                if(comparer.Compare(max, tmp) < 0)
                {
                    item = iter.Current;
                    max = tmp;
                }
            }
            return item;
        }
    }

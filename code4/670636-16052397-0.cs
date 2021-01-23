    public static class MyEnumerable
    {
        public static IEnumerable<TSource> Descending<TSource>(this IEnumerable<TSource> source)
            where TSource : IComparable<TSource>
        {
            using (var e = source.GetEnumerator())
            {
                TSource previous;
                if (e.MoveNext())
                {
                    previous = e.Current;
                    while (e.MoveNext())
                    {
                        if (previous.CompareTo(e.Current) > 0)
                            yield return e.Current;
                        previous = e.Current;
                    }
                }
            }
        }
    }

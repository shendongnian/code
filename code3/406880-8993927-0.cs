    static class EnumerableExtensions
    {
        public static IEnumerable<T> Delimit<T>(this IEnumerable<T> source, T separator)
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        yield return separator;
                        yield return enumerator.Current;
                    }
                }
            }
        }
    }

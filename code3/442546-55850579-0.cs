csharp
    public static class LinqExtensions
    {
        public static TValue Max<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector, TValue defaultValueIfEmpty)
            where TValue : IComparable
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            TValue sum;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return defaultValueIfEmpty;
                sum = selector(enumerator.Current);
                while (enumerator.MoveNext())
                {
                    var num2 = selector(enumerator.Current);
                    if (num2.CompareTo(sum) > 0)
                        sum = num2;
                }
            }
            return sum;
        }
        public static TSource Max<TSource>(this IEnumerable<TSource> source, TSource defaultValueIfEmpty)
            where TSource : IComparable
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            TSource sum;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return defaultValueIfEmpty;
                sum = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    var num2 = enumerator.Current;
                    if (num2.CompareTo(sum) > 0)
                        sum = num2;
                }
            }
            return sum;
        }
    }

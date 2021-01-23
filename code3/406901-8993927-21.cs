    static class DelimitExtensions
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
        public static IEnumerable<T> Delimit<T>(this IEnumerable<T> source, T separator, T prefix, T suffix)
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    yield return prefix;
                    yield return enumerator.Current;
                    yield return suffix;
                    while (enumerator.MoveNext())
                    {
                        yield return separator;
                        yield return prefix;
                        yield return enumerator.Current;
                        yield return suffix;
                    }
                }
            }
        }
        public static IEnumerable<T> Delimit<T>(this IEnumerable<T> source, Func<T, T, T> separator, Func<T, T> prefix, Func<T, T> suffix)
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    if (prefix != null)
                        yield return prefix(enumerator.Current);
                    yield return enumerator.Current;
                    if (suffix != null)
                        yield return suffix(enumerator.Current);
                    T previous = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        if (separator != null)
                            yield return separator(previous, enumerator.Current);
                        if (prefix != null)
                            yield return prefix(enumerator.Current);
                        yield return enumerator.Current;
                        if (suffix != null)
                            yield return suffix(enumerator.Current);
                        previous = enumerator.Current;
                    }
                }
            }
        }
        public static IEnumerable<TOut> Delimit<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> convert, Func<TIn, TIn, TOut> separator, Func<TIn, TOut> prefix, Func<TIn, TOut> suffix)
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    if (prefix != null)
                        yield return prefix(enumerator.Current);
                    yield return convert(enumerator.Current);
                    if (suffix != null)
                        yield return suffix(enumerator.Current);
                    TIn previous = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        if (separator != null)
                            yield return separator(previous, enumerator.Current);
                        if (prefix != null)
                            yield return prefix(enumerator.Current);
                        yield return convert(enumerator.Current);
                        if (suffix != null)
                            yield return suffix(enumerator.Current);
                        previous = enumerator.Current;
                    }
                }
            }
        }
    }

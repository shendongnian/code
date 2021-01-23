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

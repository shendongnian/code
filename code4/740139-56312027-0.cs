    public static IEnumerable<IEnumerable<T>> ZipMany<T>(params IEnumerable<T>[] sources)
    {
        return ZipRecursive(sources);
        IEnumerable<IEnumerable<T>> ZipRecursive(IEnumerable<IEnumerable<T>> ss)
        {
            if (!ss.Skip(1).Any())
            {
                return ss.First().Select(i => Enumerable.Repeat(i, 1));
            }
            else
            {
                return ZipRecursive(ss.Skip(1)).Zip(ss.First(), (x, y) => x.Prepend(y));
            }
        }
    }

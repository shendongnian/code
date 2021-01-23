    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
    {
        return source ?? Enumerable.Empty<T>();
    }
    public static void DisposeIfNotNull(this IDisposable source)
    {
        if (source != null)
            source.Dispose();
    }

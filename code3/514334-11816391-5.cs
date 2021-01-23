    public static IEnumerable<T[]> Slices<T>(this T[] source, int count)
    {
        for (var i = 0; i < source.Count(); i += count)
            yield return source.CopySlice(i, count);
    }

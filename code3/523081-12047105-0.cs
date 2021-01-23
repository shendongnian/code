    public static T[] ToArray<T>(this string s, Func<string, T> converter, params char[] seps)
    {
        return s.Split(seps.Length > 0 ? seps : new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(converter)
                .ToArray();
    }

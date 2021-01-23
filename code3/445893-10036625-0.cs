    public static bool IsInAny(this IEnumerable<String> source, string name, string delim = " ")
    {
        return source.Any(item =>
                              {
                                 var splits = name.Split(new[] { delim }, StringSplitOptions.RemoveEmptyEntries);
                                 return splits.Contains(item);
                              });
    }

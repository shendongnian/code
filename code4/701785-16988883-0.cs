    public static IEnumerable<IEnumerable<T>> Permuatations<T>(
        this IEnumerable<T> source)
    {
        var list = source.ToList();//becase we iterate it multiple times
        return list.SelectMany((item, i) => list.Where((_, index) => index != i)
                .Permuatations()
                .Select(subsequence => new[] { item }.Concat(subsequence)))
            .DefaultIfEmpty(Enumerable.Empty<T>());
    }

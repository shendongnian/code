    public static IEnumerable<IEnumerable<T>> AllCombinations<T>(this IList<T> source)
    {
        IEnumerable<IEnumerable<T>> output = Enumerable.Empty<IEnumerable<T>>();
        for (int i = 1; i < source.Count; i++)
        {
            output = output.Concat(Combinations(source, i));
        }
        return output;
    }

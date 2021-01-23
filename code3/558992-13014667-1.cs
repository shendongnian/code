    public static IEnumerable<IEnumerable<T>> AllCombinations<T>(this IList<T> source)
    {
        IEnumerable<IEnumerable<T>> output = Enumerable.Empty<IEnumerable<T>>();
        for (int i = 0; i < source.Count; i++)
        {
            output = output.Concat(source.Combinations(i));
        }
        return output;
    }

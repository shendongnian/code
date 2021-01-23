    public static IEnumerable<int> FindAllIndices<T>(this IList<T> source, T value)
    {
      return Enumerable.Range(0, source.Count)
        .Where(i => object.Equals(source[i], value));
    }

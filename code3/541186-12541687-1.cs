    public static IEnumerable<int> FindAllIndexes(this IEnumerable<T> haystack,
                                                  T needle) where T : IEquatable<T>
    {
        int index = 0;
        foreach (var item in haystack)
        {
            if (item.Equals(needle))
            {
                yield return index;
            }
            index++;
        }
    }

    public static IEnumerable<IEnumerable<T>> SplitIntoSets<T>
        (this IEnumerable<T> source, int itemsPerSet) 
    {
        var sourceList = source as List<T> ?? source.ToList();
        var result = new List<IEnumerable<T>>();
        for (var index = 0; index < sourceList.Count; index += itemsPerSet)
        {
            result.Add(sourceList.Skip(index).Take(itemsPerSet));
        }
        return result;
    }

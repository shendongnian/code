    public static IEnumerable<IEnumerable<T>> BulkForEach<T>(this IEnumerable<T> list, int size = 1000)
    {
        for (int index = 0; index < list.Count() / size + 1; index++)
        {
            IEnumerable<T> returnVal = list.Skip(index * size).Take(size).ToList();
            yield return returnVal;
        }
    }

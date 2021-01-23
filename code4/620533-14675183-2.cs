    public static void BulkForEach<T>(this IEnumerable<T> list, Action<IEnumerable<T>> action, int size = 1000)
    {
        for (int index = 0; index < list.Count() / size + 1; index++)
        {
            IEnumerable<T> returnVal = list.Skip(index * size).Take(size).ToList();
            action.Invoke(returnVal);
        }
    }

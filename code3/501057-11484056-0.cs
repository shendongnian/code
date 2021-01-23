    public static void AddIfNotExist<T>(this List<T> list, T item)
    {
        if (list.Contain(item))
        {
            list.Add(item);
        }
    }

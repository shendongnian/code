    public static void RemoveIfTrue<T>(this List<T> list, Func<T, bool> condition)
    {
        List<T> itemsToRemove = list.Where(condition).ToList();
        foreach (var item in itemsToRemove)
        {
            list.Remove(item);
        }
    }

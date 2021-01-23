    public static List<List<T>> Split<T>(this List<T> items, int sliceSize = 30)
    {
        List<List<T>> list = new List<List<T>>();
        for (int i = 0; i < items.Count; i += sliceSize)
            list.Add(items.GetRange(i, Math.Min(sliceSize, items.Count - i)));
        return list;
    } 

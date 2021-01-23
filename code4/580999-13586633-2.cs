    public static List<List<T>> Transpose<T>(List<List<T>> lists)
    {
        var longest = lists.Any() ? lists.Max(l => l.Count) : 0;
        List<List<T>> outer = new List<List<T>>(longest);
        for (int i = 0; i < longest; i++)
            outer.Add(new List<T>(lists.Count));
        for (int j = 0; j < lists.Count; j++)
            for (int i = 0; i < longest; i++)
                outer[i].Add(lists[j].Count > i ? lists[j][i] : default(T));
        return outer;
    }

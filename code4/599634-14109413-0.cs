    public static bool AllSame<T>(List<T> list)
    {
        return list.Count == 0 || list.FindAll(delegate(T x)
            { return !EqualityComparer<T>.Default.Equals(x, list[0]); }).Count == 0;
    }

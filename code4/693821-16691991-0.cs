    public static void Synchronize<T>(this ICollection<T> first, ICollection<T> second)
    {
        first.RemoveAll();
        foreach (var s in second) { first.Add(s); }
    }

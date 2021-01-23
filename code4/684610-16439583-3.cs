    public static bool Any<T>(this IEnumerable<T> data)
    {
        Log();
        using (var iter = data.GetEnumerator())
        {
            return iter.MoveNext();
        }
    }
    static void Log([CallerMemberName] string name = null)
    {
        Console.WriteLine(name);
    }
    public static T First<T>(this IEnumerable<T> data)
    {
        Log();
        using (var iter = data.GetEnumerator())
        {
            if (iter.MoveNext()) return iter.Current;
            throw new InvalidOperationException();
        }
    }
    public static IEnumerable<T> Where<T>(this IEnumerable<T> data, Func<T,bool> predicate)
    {
        Log();
        foreach (var item in data) if (predicate(item)) yield return item;
    }
    public static IEnumerable<T> Except<T>(this IEnumerable<T> data, IEnumerable<T> except)
    {
        Log();
        var exclude = new HashSet<T>(except);
        foreach (var item in data)
        {
            if (!exclude.Contains(item)) yield return item;
        }
    }

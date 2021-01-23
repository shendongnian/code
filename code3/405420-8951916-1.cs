    public static Dictionary<T, int> GroupCount<T>(this IEnumerable<T> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        var map = new Dictionary<T, int>();
        foreach (T value in source)
        {
            int count;
            map.TryGetValue(number, out count);
            map[number] = count + 1;
        }
        return map;
    }

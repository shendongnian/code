    public static int NextAvailableInteger(this IEnumerable<int> ints)
    {
        return NextAvailableInteger(ints, 1); // by default we use one
    }
    public static int NextAvailableInteger(this IEnumerable<int> ints, int defaultValue)
    {
        if (ints == null || ints.Count() == 0) return defaultValue;
        var ordered = ints.OrderBy(v => v);
        int counter = ints.Min();
        int max = ints.Max();
        while (counter < max)
        {
            if (!ordered.Contains(++counter)) return counter;
        }
        return (++counter);
    }

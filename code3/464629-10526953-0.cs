    public static IEnumerable<DateTime> CutTimes(IEnumerable<DateTime> source)
    {
        var count = source.Count();
        var ignore = count % 4;
        if (ignore != 0)
        {
            source = source.Take(count - ignore);
        }
        return source.Where((time, index) => index % 4 == 0 || index % 4 == 3);
    }

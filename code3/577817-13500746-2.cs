    public static List<T> Repeat<T>(this IEnumerable<T> lstEnum, int count) {
        if (count < 0)
            throw new ArgumentOutOfRangeException("count");
        var lst = lstEnum.ToList(); // Enumerate only once
        var ret = Enumerable.Empty<T>();
        for (var i = 0; i < count; i++)
            ret = ret.Concat(lst);
        return ret.ToList();
    }

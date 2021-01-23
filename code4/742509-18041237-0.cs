    public static int Count(Inner inner)
    {
        var count = 1;
        if (inner.Inners != null && inner.Inners.Any())
           count += inner.Inners.Sum(x => Count(x));
        return count;
    }

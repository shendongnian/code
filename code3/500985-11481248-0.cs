    public static Foo FirstBeyondSum(this IEnumerable<Foo> source, int value)
    {
        var sum = 0;
        foreach(var item in source)
        {
            sum += item.Value;
            if(sum >= value)
            {
                return item;
            }
        }
        return null;
    }

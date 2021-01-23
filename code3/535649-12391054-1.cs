    public static IEnumerable BackwardsIterator(this List l)
    {
        foreach(var item in l.AsEnumerable().Reverse())
        {
            yield return item;
        }
    }

    public static void int FindLongestLength(params ArrayList[] lists)
    {
        return lists == null 
            ? -1 // here you could also return (int?)null,
                 // all you need to do is adjusting the return type
            : lists.Max(x => x.Count);
    }

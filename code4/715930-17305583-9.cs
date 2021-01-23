    public static List<List<int>> Test1(List<int>[] lists)
    {
        var result = new List<List<int>>();
        foreach(var list in lists)
        {
            list.Sort();
            if(!result.Any(elm => elm.SequenceEqual(list)))
                result.Add(list);
        }
        return result;
    }

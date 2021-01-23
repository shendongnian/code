    //                                            v-- this is missing in your code
    static List<Int32> Example(params List<Int32>[] lsts)
    {
        List<Int32> result = new List<int>();
        foreach (var lst in lsts)
        {
            result = result.Concat(lst).ToList();
        }
        return result.Distinct().OrderBy(c => c).ToList();
    }

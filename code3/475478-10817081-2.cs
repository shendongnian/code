    public static int AddNext(this Dictionary<int, string> dict)
    {
        int min = dict.Keys.Min();
        int max = dict.Keys.Max();
        return Enumerable.Range(min, max-min).Except(dict.Keys).First();   
    }

    var res2 = s.SplitEvery(4).ToList();
    public static IEnumerable<string> SplitEvery(this string s, int n)
    {
        int index = 0;
        return s.GroupBy(_=> index++/n).Select(g => new string(g.ToArray()));
    }

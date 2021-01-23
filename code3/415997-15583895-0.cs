    public static string ToCommaString(this List<int> list)
    {
        if (list.Count <= 0)
            return ("");
        if (list.Count == 1)
            return (list[0].ToString());
        System.Text.StringBuilder sb = new System.Text.StringBuilder(list[0].ToString());
        for (int x = 1; x < list.Count; x++)
            sb.Append("," + list[x].ToString());
        return (sb.ToString());
    }
    public static List<int> CommaStringToIntList(this string _s)
    {
        string[] ss = _s.Split(',');
        List<int> list = new List<int>();
        foreach (string s in ss)
            list.Add(Int32.Parse(s));
        return (list);
    }

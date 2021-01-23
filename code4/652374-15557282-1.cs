    public static string PrefixPart(string str)
    {
        return
            string.Join("(?:", str.Select(i => Regex.Escape(i.ToString())))
            + string.Join(")?", Enumerable.Repeat(string.Empty, str.Length));
    }
    public static string SuffixPart(string str)
    {
        return PrefixPart(new string(str.Reverse().ToArray()));
    }
    public static string Combined(string str1, string str2)
    {
        string left = SuffixPart(str1) + ".?" + PrefixPart(str2);
        string right = SuffixPart(str2) + ".?" + PrefixPart(str1);
        return string.Format("^{0}|{1}$", left, right);
    }

    public static string ReplaceOnce(this string s, string replace, string with)
    {
        return s.ReplaceCount(replace, with);
    }
    public static string ReplaceCount(this string s, string replace, string with, int howManytimes = 1)
    {
        if (howManytimes < 0) throw InvalidOperationException("can not replace a string less than zero times");
        int count = 0;
        while (s.Contains(replace) && count < howManytimes)
        {
            int position = s.IndexOf(replace);
            s = s.Remove(position, replace.Length);
            s = s.Insert(position, with);
            count++;
        }
        return s;
    }

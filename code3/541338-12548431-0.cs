    public static string InsertAtIntervals(this string s, int interval, string value)
    {
        if (s == null || s.Length <= interval) {
            return s;
        }
        var sb = new StringBuilder(s);
        for (int i = interval * ((s.Length - 1) / interval); i > 0; i -= interval) {
            sb.Insert(i, value);
        }
        return sb.ToString();
    }

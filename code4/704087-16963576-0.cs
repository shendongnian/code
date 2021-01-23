    public static string EnsureExactLength(this string s, int length)
    {
        if (s == null)
            throw new ArgumentNullException("null");
        return s.PadRight(length).Substring(0, length);
    }

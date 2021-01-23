    public static bool EndsWith(this StringBuilder sb, string test)
    {
        if (sb.Length < test.Length)
            return false;
        string end = sb.ToString(sb.Length - test.Length, test.Length);
        return end.Equals(test);
    }

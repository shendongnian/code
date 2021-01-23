    public static int SubsetCount(this string s)
    {
        return 2 << s.Length;
    }
    public static string NthSubset(this string s, int n)
    {
        var b = New StringBuilder();
        int i = 0;
        while (n > 0)
        {
            if ((n&1)==1) b.Append(s[i]);
            i++;
            n >>= 1;
        }
        return b.ToString();
    }

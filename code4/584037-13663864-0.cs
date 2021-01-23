    private static List<string> s = new List<string> { "a", "b" };
    static string GenRan()
    {
        int r = Rand();
        string a = null;
        if (r == 1)
        {
            a += s[0];
            s.RemoveAt(0);
        }
        if (r == 2)
        {
            a += s[1];
            s.RemoveAt(1);
        }
        return a;
    }

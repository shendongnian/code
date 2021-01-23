    public static bool IsAnagram(String s, String t)
    {
        if (s.Length != t.Length)
            return false;
        var ta = t.ToCharArray();
        foreach (char ch in s)
        {
            int x = Array.IndexOf(ta, ch);
            if (x < 0)
                return false;
            ta[x] = '\0';
        }
        return true;
    }

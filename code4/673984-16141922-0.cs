    public static bool IsAnagram(string s1, string s2)
    {
        var q1 = s1.OrderBy(c => s1.IndexOf(c));
        var q2 = s1.OrderByDescending(c => s2.IndexOf(c));
        return q1.SequenceEqual(q2);
    }

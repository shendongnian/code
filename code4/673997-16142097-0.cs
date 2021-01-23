    public static bool IsAnagram(this string s1, string s2)
    {
        if (s1.Length == s2.Length)
        {
            var count = new int[256];
            foreach (var t in s1)
            {
                ++count[t];
            }
            return s2.All(t => --count[t] >= 0);
        }
        return false;
    }
    
    var result = "abcd".IsAnagram("adbc");

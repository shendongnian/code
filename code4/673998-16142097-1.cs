    public static bool IsAnagram(this string s1, string s2)
    {
        if (s1.Length == s2.Length)
        {
            var count = new int[1024];
            foreach (var c in s1)
            {
                ++count[c];
            }
            return s2.All(t => --count[c] >= 0);
        }
        return false;
    }
    
    var result = "mary".IsAnagram("army");

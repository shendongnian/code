    public static bool IsAnagram(string s1, string s2)
    {
        foreach (char c in s2)
        {
            if (s1.Last() == c)
            {
              s1 = s1.Remove(s1.Length-1);
            }
        }
    
        return string.IsNullOrEmpty(s1);
    }

    string s1 = "Chrx";
    string s2 = "Christopher";
    IsMatchOn2Characters(s1, s2);
    static bool IsMatchOn2Characters(string a, string b)
    {
        string s1 = a.ToLowerInvariant();
        string s2 = b.ToLowerInvariant();
        
        for (int i = 0; i < s1.Length - 1; i++)
        {
           if (s2.IndexOf(s1.Substring(i,2)) >= 0)
              return true; // match
        }
           
        return false; // no match
    }

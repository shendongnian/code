    public static bool checkStringForUpperCase(string s) 
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsUpper(s[i]))
                return false;
        }
        return true;
    }

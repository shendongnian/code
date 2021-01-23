     public string GetString(string s, int substringLen, int skipCount)
    {
        StringBuilder newString = new StringBuilder(s.Length);
        for (int i = 0; i < s.Length; i += skipCount)
        {
            for (int j = 0; j < substringLen && i < s.Length; j++)
            {
                newString.Append(s[i++]);
            }
        }
        return newString.ToString();
    }

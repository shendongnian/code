    static string SwapCharacters(string s)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i += 2)
        {
            if (i < s.Length - 1)
                sb.Append(s[i + 1]);
            sb.Append(s[i]);
        }
        return sb.ToString();
    }

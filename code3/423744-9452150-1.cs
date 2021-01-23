    static string SwapCharacters(string s, char c1, char c2)
    {
        StringBuilder sb = new StringBuilder(s);
        for (int i = 0; i < s.Length; ++i)
            if (s[i] == c1)
                sb[i] = c2;
            else if (s[i] == c2)
                sb[i] = c1;
        return sb.ToString();
    }

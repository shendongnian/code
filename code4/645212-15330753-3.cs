    public static string RemoveWhiteSpaces(this string str)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if (!Char.IsWhiteSpace(c))
                sb.Append(c);
        }
        return sb.ToString();
    }

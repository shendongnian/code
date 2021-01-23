    public static String TrimBetween(this string text, int maxWhiteSpaces = 1)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        foreach (Char c in text)
        {
            if (!Char.IsWhiteSpace(c))
            {
                count = 0;
                sb.Append(c);
            }
            else
            {
                if (++count <= maxWhiteSpaces)
                    sb.Append(c);
            }
        }
        return sb.ToString();
    }

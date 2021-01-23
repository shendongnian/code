    public static string RemoveWhiteSpaces(this string str)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            switch (c)
            {
                case '\r':
                case '\n':
                case '\t':
                case ' ':
                    continue;
                default:
                    sb.Append(c);
                    break;
            }
        }
        return sb.ToString();
    }

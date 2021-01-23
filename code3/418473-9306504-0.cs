    static string RemoveSpaces(String s)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
            if (c != ' ')
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

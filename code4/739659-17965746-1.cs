    public static string RemoveExcessSpaces(this string str)
    {
        StringBuilder sb = new StringBuilder(str.Length);
        bool first = true;
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            switch (c)
            {
                case '\r':
                case '\n':
                case '\t':
                case ' ':
                    if(first)
                    {
                        sb.Append(c);
                        first = false;
                    }
                    else
                        continue;
                    break;
                default:
                    sb.Append(c);
                    first = true;
                    break;
            }
        }
        return sb.ToString();
    }

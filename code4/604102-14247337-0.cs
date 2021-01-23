    public static List<string> MySplit(string input)
    {
        List<string> split = new List<string>();
        StringBuilder sb = new StringBuilder();
        bool splitOnQuote = false;
        char quote = '"';
        char space = ' ';
        foreach (char c in input.ToCharArray())
        {
            if (splitOnQuote)
            {
                if (c == quote)
                {
                    if (sb.Length > 0)
                    {
                        split.Add(sb.ToString());
                        sb.Clear();
                    }
                    splitOnQuote = false;
                }
                else { sb.Append(c); }
            }
            else
            {
                if (c == quote)
                {
                    if (sb.Length > 0)
                    {
                        split.Add(sb.ToString());
                        sb.Clear();
                    }
                    splitOnQuote = true;
                }
                else if (c == space)
                {
                    if (sb.Length > 0)
                    {
                        split.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                else { sb.Append(c); }
            }
        }
                
        return split;
    }

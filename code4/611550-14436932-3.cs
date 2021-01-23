    string SplitOnWholeWord(string toSplit, int maxLineLength)
    {
        StringBuilder sb = new StringBuilder();
        string[] parts = toSplit.Split();
        string line = string.Empty;
        foreach(string s in parts)
        {
            if(s.Length > 32)
            {
                string p = s;
                while(p.Length > 32)
                {
                    int addedChars = 32 - line.Length;
                    line = string.Join(" ", line, p.Substring(0, addedChars));
                    sb.AppendLine(line);
                    p = p.Substring(addedChars);
                    line = string.Empty;
                }
                line = p;
            }
            else
            {
                if(line.Length + s.Length > maxLineLength)
                {
                    sb.AppendLine(line);
                    line = string.Empty;
                }
                line = (line.Length > 0 ? string.Join(" ", line, s) : s);
            }
        }
        sb.Append(line.Trim());
        return sb.ToString();
    }

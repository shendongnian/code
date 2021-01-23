    static string ReplaceCallback(Match match)
    {
        var sb = new StringBuilder("<span class=\"");
        sb.Append(match.Groups[1].Captures[0].Value);
        for(int i = 1; i < match.Groups[1].Captures.Count; i++)
        {
            sb.Append(" ");
            sb.Append(match.Groups[1].Captures[i].Value);
        }
        sb.Append("\">");
        sb.Append(match.Groups[2].Value);
        sb.Append("</span>");
        return sb.ToString();
    }

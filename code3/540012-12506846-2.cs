    var regHeaders = new Regex(@"<h(?<header>\d)\s*>(?<content>.+?)</h\1>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
    var replaced = regHeaders.Replace(sb.ToString(), EvaluateHeaders);
    
    private static string EvaluateHeaders(Match m)
    {
        switch(int.Parse(m.Groups["header"].Value))
        {
            case 1: // <h1>content</h1>
                return string.Format("<h1><a href=\"#\" id=\"{0}\">{0}</a><h1>", m.Groups["content"].Value);
            default:
                return m.Value;
        }
    }

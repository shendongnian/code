    private static List<string> TakeLastLines(string text, int count)
    {
        List<string> lines = new List<string>();
        Match match = Regex.Match(text, "^.*$", RegexOptions.Multiline | RegexOptions.RightToLeft);
        while (match.Success && lines.Count < count)
        {
            lines.Insert(0, match.Value);
            match = match.NextMatch();
        }
        return lines;
    }

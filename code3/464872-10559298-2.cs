    private string FormatInput(string input)
    {
        const string patternNonGreedy = @"\{(?<tag>.+?):(\s*)(?<content>.*?)(\s*)}";
        const string patternGreedy = @"\{(?<tag>.+?):(\s*)(?<content>.*)(\s*)}";
        Match mtc = Regex.Match(input, patternGreedy);
        if (!mtc.Success)
            return input;
        string content = mtc.Groups["content"].Value;
        int braces = 0;
        foreach (char c in content)
        {
            if (c == '{')
                braces++;
            else if (c == '}')
            {
                if (braces > 0)
                    braces--;
            }
        }
        if (braces == 0)
            return input.Substring(0, mtc.Index)
                + string.Format("<{0}>{1}</{0}>", mtc.Groups["tag"].Value, FormatInput(content))
                + input.Substring(mtc.Index + mtc.Length);
        mtc = Regex.Match(input, patternNonGreedy);
        Debug.Assert(mtc.Success);
        content = mtc.Groups["content"].Value;
        return input.Substring(0, mtc.Index)
            + string.Format("<{0}>{1}</{0}>", mtc.Groups["tag"].Value, content)
            + FormatInput(input.Substring(mtc.Index + mtc.Length));
    }

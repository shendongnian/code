    private Regex angleReg = new Regex(@"<([^>]+)>\s+<([^>]+)>");
    private string[] parse(string rawInput)
    {
        Match angleMatch = angleReg.Match(rawInput);
        if (angleMatch.Success)
        {
            return new string[] { angleMatch.Groups[1].Value, angleMatch.Groups[2].Value };
        }
        else
        {
            return null;
        }
    }

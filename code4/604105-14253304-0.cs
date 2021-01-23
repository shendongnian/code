    static Regex re = new Regex(@"^([ ]*((?<r>[^ ""]+)|[""](?<r>[^""]*)[""]))*[ ]*$");
    public static IEnumerable<string> RegexSplit(string input)
    {
        var m = re.Match(input ?? "");
        if(!m.Success)
            throw new ArgumentException("Malformed input.");
        return from Capture capture in m.Groups["r"].Captures select capture.Value;
    }

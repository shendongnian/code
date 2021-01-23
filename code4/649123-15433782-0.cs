    public static string Format(string input)
    {
        Regex regex = new Regex(@"^(\d+)(.*)$");
        var match = regex.Match(input);
        if (match.Success)
        {
            input = Int32.Parse(match.Groups[1].Value).ToString("N2");
            input += " " + match.Groups[2].Value;
        }
        return input;
    }
    

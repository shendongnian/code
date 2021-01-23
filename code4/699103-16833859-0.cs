    static int ExtractNumber(string text)
    {
        Match match = Regex.Match(text, @"_(\d+)\.(png)");
        if (match == null)
        {
            return 0;
        }
    
        int value;
        if (!int.TryParse(match.Value, out value))
        {
            return 0;
        }
    
        return value;
    }

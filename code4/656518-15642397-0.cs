    bool ChechResult(int value)
    {
        String input = @"L( 24, 25, 26, 27)";
        String pattern = @"\d+";
        foreach (Match match in Regex.Matches(input, pattern))
        {
            if(value == int.Parse(match.Value))
            {
                return true;
            }
        }
        return false;
    }

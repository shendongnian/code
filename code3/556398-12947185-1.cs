    public static string ReplaceLength(string s, int maxLength)
    {
        return Regex.Replace(s, @"CHARACTER VARYING\((?<length>\d+)\)",
                match => "varchar(" + (
                                       int.Parse(match.Groups["length"].Value) <= maxLength ? 
                                            match.Groups["length"].Value : 
                                            "MAX"
                                      ) + 
                                ")");
    }

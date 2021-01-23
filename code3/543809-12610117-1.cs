    var pattern = @"([a-z]+) ([a-z]+)";
    var format = "[starts-with({0}{1}]";
    
    var input = "bla bla";
    var result = ReplacePattern(input, pattern, format);
    
    public static string ReplacePattern(string input, string pattern, string format)
    {
       if (Regex.Match(input, pattern).Groups.Count != 3) return input;//or throw, or...
       return Regex.Replace(input, pattern, x =>
                string.Format(format,
                              x.Groups[1].Value.ToUpper(), 
                              x.Groups[2].Value));
    }

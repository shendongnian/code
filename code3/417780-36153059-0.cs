    static void Main(string[] args)
    {
        var param = ParseString(Environment.CommandLine);
        ... 
    }
        
    // the following template implements the following notation:
    // -key1 = some value   -key2 = "some value even with '-' character "  ...
    private const string ParameterQuery = "\\-(?<key>\\w+)\\s*=\\s*(\"(?<value>[^\"]*)\"|(?<value>[^\\-]*))\\s*";
    private static Dictionary<string, string> ParseString(string value)
    {
       var regex = new Regex(ParameterQuery);
       return regex.Matches(value).Cast<Match>().ToDictionary(m => m.Groups["key"].Value, m => m.Groups["value"].Value);
    } 

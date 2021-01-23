    public static void Main(string[] args)
    {
        string parsedPath = null;
        Dictionary<string, string> parsedValues = new Dictionary<string, string>();
        var set = new OptionSet() 
        { 
            { "p=", "the project path", v => parsedPath = v }, 
            { "s=", "a setting", (m, v) => { parsedValues.Add(m, v); } },
        };
        set.Parse(args);
        Console.WriteLine(parsedPath ?? "<NULL>");
        foreach (var keyValuePair in parsedValues)
        {
            Console.WriteLine(keyValuePair.Key + "::::" + keyValuePair.Value);
        }
    }

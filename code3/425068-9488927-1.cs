    string input = "2012-02-25 07:53:04";
    
    // These can be private static readonly fields. They're thread-safe
    var inputPattern = LocalDateTimePattern.CreateWithInvariantInfo("yyyy-MM-dd HH:mm:ss");
    var outputPattern = LocalDateTimePattern.CreateWithInvariantInfo("dd-MM-yy HH:mm:ss");
    
    var parsed = inputPattern.Parse(input);
    if (!parsed.Success)
    {
        Console.WriteLine("Couldn't parse value");
    }
    else
    {
        string formatted = outputPattern.Format(parsed.Value);
        Console.WriteLine("Formatted to: {0}", formatted);
    }

    public static IEnumerable<string> SeverityOrHigher(string severity)
    {
        var result = new List<string>() 
            { "ALL", "DEBUG", "INFO", "WARN", "ERROR", "FATAL", "OFF" };
        return result.SkipWhile(l => l != severity.ToUpper()).ToArray();
    }

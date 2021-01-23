    public static IEnumerable<string> SeverityOrHigher(string severity)
    {
        var result = new List<string>();
        var severities = new List<string> { "ALL", "DEBUG", "INFO", "WARN", "ERROR", "FATAL", "OFF" };
        severity = severity.ToUpper();
        if (severities.Contain(severity))
                result.Add(severity);
        return result;
    }

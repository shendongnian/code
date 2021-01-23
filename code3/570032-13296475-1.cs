    public static Dictionary<string, string> GetReports(XElement report)
    {
        var output = new Dictionary<string, string>();
        foreach(var field in fieldNames)
        {
            output.Add(field, report.Elements(fieldName).First().Value);
        }
    }

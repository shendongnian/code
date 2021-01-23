    public static Dictionary<string, string> GetReports(XElement report)
    {
        var output = new Dictionary<string, string>();
        foreach(var field in report.Decendents())
        {
            output.Add(field.Name, ...);
        }
    }

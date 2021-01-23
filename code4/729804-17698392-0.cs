    private static string CreateCSVTextFile<T>(List<T> data, string seperator = ",")
        where T : ExcelReport, new()
    {
        var properties = typeof(T).GetProperties();
        var result = new StringBuilder();
        
        foreach (var row in data)
        {
            var values = properties.Select(p => p.GetValue(row, null));
            var line = string.Join(seperator, values);
            result.AppendLine(line);
        }
        
        return result.ToString();
    }

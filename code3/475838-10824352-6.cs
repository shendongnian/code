    /// <summary>
    /// Converts a CSV string to a Json array format.
    /// </summary>
    /// <remarks>First line in CSV must be a header with field name columns.</remarks>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string CsvToJson(this string value)
    {
        // Get lines.
        if (value == null) return null;
        string[] lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2) throw new InvalidDataException("Must have header line.");
    
        // Get headers.
        string[] headers = lines.First().SplitQuotedLine(new char[] { ',' }, false);
    
        // Build JSON array.
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("[");
        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].SplitQuotedLine(new char[] { ',', ' ' }, true, '"', false);
            if (fields.Length != headers.Length) throw new InvalidDataException("Field count must match header count.");
            var jsonElements = headers.Zip(fields, (header, field) => string.Format("{0}: {1}", header, field)).ToArray();
            string jsonObject = "{" + string.Format("{0}", string.Join(",", jsonElements)) + "}";
            if (i < lines.Length - 1)
                jsonObject += ",";
            sb.AppendLine(jsonObject);
        }
        sb.AppendLine("]");
        return sb.ToString();
    }

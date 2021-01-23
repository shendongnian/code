    var allLines = System.IO.File.ReadAllLines(path);
    DataTable result = extractSchemaTable(allLines);
    for (int i = 0; i < allLines.Length; i++)
    {
        String line = allLines[i];
        if (line.StartsWith("("))
        {
            String data = line.Substring(1, line.Length - (line.Length - line.LastIndexOf(")")) - 1);
            var fields = data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            result.Rows.Add(fields);
        }
    }

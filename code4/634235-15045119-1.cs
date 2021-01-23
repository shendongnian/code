    Dictionary<string, string> columnValues = new Dictionary<string, string>();
    for (int i = 0; i < columnsCount; i++)
    {
        foreach (string[] values in linesValues)
        {
            if (!columnValues.ContainsKey(values[i]))
            {
                columnValues.Add(values[i], columnHeaders[i]);
            }
        }
    }

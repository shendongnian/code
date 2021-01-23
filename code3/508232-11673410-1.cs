    [Invoke] // Use invoke for non-entities
    public string[] GetColumnNames(string table)
    {
        // Format the SQL and get the results;
        return columnNames.ToArray();
    }

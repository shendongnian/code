    public static DataTable Filter(this DataTable dataTable, string selectFilter)
    {
        var filteredTable = dataTable.Clone();
        var rows = dataTable.Select(selectFilter).ToList();
        rows.ForEach(filteredTable.ImportRow);
        return filteredTable;
    }

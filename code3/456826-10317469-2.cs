    public static DataTable GetFilteredTable(
        DataTable sourceTable, string selectFilter)
    {
        var filteredTable = sourceTable.Clone();
        var rows = sourceTable.Select(selectFilter);
        foreach (DataRow row in rows)
        {
            filteredTable.ImportRow(row);
        }
        return filteredTable;
    }
    
    DataTable dataTable = GetFilteredTable(
        DS.Tables[0], "STAGENAME='Develop' AND DEVLAPSEDAYS IS NOT NULL");

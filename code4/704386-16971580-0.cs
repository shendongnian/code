    List<TableInfo> tables = new List<TableInfo>();
    int i = 0;
    foreach (DataTable dt in dtImportedTables.Tables)
    {
        TableInfo table = new TableInfo
        {
            Name = Globals.tblSchemaTable.Rows[i][2].ToString(),
            // Do you really need this? Won't it be the same as Columns.Count?
            ColumnCount = dt.Columns.Count,
            Columns = new List<ColumnInfo>()
        };
    
        foreach (DataColumn dc in dt.Columns)
        {
            table.Columns.Add(new ColumnInfo {
                                Name = dc.ColumnName,
                                Type = dc.DataType.Name
                              });
        }
        tables.Add(table); 
        // I assume you meant to include this?
        i++;
    }

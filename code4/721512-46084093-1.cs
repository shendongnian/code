    public static void AutoMapColumns(SqlBulkCopy sbc, DataTable dt)
    {
        foreach (DataColumn column in dt.Columns)
        {
            sbc.ColumnMappings.Add(
                new SqlBulkCopyColumnMapping(column.ColumnName, column.ColumnName));
        }
    }

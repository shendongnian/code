    IEnumerable<DataRow> rows = MyDataTable.Rows.Cast<DataRow>();
    Dictionary<string, List<ColumnInfo>> ExistingColumns = rows
        .GroupBy(r => r["TABLE_NAME"].ToString(),
                 r => new ColumnInfo {
                     ColumnName = r["COLUMN_NAME"].ToString(),
                     DataType = r["DATA_TYPE"].ToString(),
                     DataLength = Int32.Parse(r["DATA_LENGTH"].ToString())
                 }
            )
        .ToDictionary(g => g.Key, g => g.ToList());

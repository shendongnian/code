    var query = MyDataTable.AsEnumerable()
                           .GroupBy(row => row["TABLE_NAME"].ToString())
                           .ToDictionary(g => g.Key,
        g => g.Select(row => new ColumnInfo()
        { 
            ColumnName = row["COLUMN_NAME"].ToString(), 
            DataType = row["DATA_TYPE"].ToString(), 
            DataLength = int.Parse(row["DATA_LENGTH"].ToString())
        }));

    public List<string> CopyDistinctColumns(DataTable source, DataTable target)
    {
        var copiedColumn = new List<string>();
        for(var x = 0; x < source.Columns.Count; x++)
        {
            var column = source.Columns[x];
            if(!target.Columns.Contains(column.ColumnName))
            {
                var newCol = new DataColumn
                {
                    ColumnName = column.ColumnName,
                    DataType = column.DataType,
                    Caption = column.Caption,
                    DefaultValue = column.DefaultValue,
                    MaxLength = column.MaxLength,
                };
                copiedColumn.Add(column.ColumnName);
                target.Columns.Add(newCol);
            }
        }
        return copiedColumn;
    }
    public void CopyData(DataTable source, DataTable target, string primaryKeyColumnName, List<string> copiedColumns)
    {
        for (var i = 0; i < source.Rows.Count; i++)
        {
            var row = source.Rows[i];
            var primaryKeyValue = row[primaryKeyColumnName];
            for (var j = 0; j < target.Rows.Count; j++)
            {
                var trow = target.Rows[j];
                if (trow[primaryKeyColumnName].Equals(primaryKeyValue))
                {
                    foreach (var col in copiedColumns)
                    {
                        trow[col] = row[col];
                    }
                    break;
                }
            }
        }
    }

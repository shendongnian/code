    public static DataTable UnpivotDataTable(DataTable pivoted)
    {
        string[] columnNames = pivoted.Columns.Cast<DataColumn>()
            .Select(x => x.ColumnName)
            .ToArray();
        var unpivoted = new DataTable("unpivot");
        unpivoted.Columns.Add(pivoted.Columns[0].ColumnName, pivoted.Columns[0].DataType);
        unpivoted.Columns.Add("Attribute", typeof(string));
        unpivoted.Columns.Add("Value", typeof(string));
            
        for (int r = 0; r < pivoted.Rows.Count; r++)
        {
            for (int c = 1; c < columnNames.Length; c++)
            {
                var value = pivoted.Rows[r][c]?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    unpivoted.Rows.Add(pivoted.Rows[r][0], columnNames[c], value);
                }
            }
        }
            
        return unpivoted;
    }

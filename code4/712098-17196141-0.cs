            DataTable dt = new DataTable();
            DataColumn column = new DataColumn()
            {
                ColumnName = defindedDataTable.Columns[0].ColumnName,
                DataType = defindedDataTable.Columns[0].DataType,
                Expression = defindedDataTable.Columns[0].Expression,
                ColumnMapping = defindedDataTable.Columns[0].ColumnMapping
            };
            dt.Columns.Add(column);

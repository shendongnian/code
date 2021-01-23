            var goodTable = new DataTable();
            var badTable = new DataTable();
            // some initialization code (add columns, fill with data)...
            var columnNames = goodTable
                .Columns
                .Cast<DataColumn>()
                .Where(column => column.ColumnName != "SkipColumn1" && column.ColumnName != "SkipColumn2")
                .Select(column => column.ColumnName)
                .ToArray();
            for (var i = 0; i < goodTable.Rows.Count; i++)
            {
                foreach (var columnName in columnNames)
                {
                    badTable.Rows[i][columnName] = goodTable.Rows[i][columnName];
                }
            }

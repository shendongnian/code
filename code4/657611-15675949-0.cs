    List<string> result = dt.Columns.Cast<DataColumn>()
                .Where(c => c.ColumnName != "pcode")
                .ToList()
                .Where(c => dt.Rows[0].Field<string>(c) == "1")
                .Select(c => c.ColumnName)
                .ToList();

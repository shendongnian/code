        foreach (DataRow row in dataTable.Rows)
        {
            List<string> currentRow = new List<string>();
            foreach (DataColumn column in dataTable.Columns)
            {
                object item = row[column];
                if (column.Ordinal == 1)
                    currentRow.Add("'" + item.ToString());
                else
                    currentRow.Add(item.ToString());
            }
            rows.Add(string.Join(",", currentRow.ToArray()));
        }

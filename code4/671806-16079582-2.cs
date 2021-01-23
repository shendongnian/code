    for (var col = dataTable.Columns.Count - 1; col >= 0; col--)
        {
            bool removeColumn = dataTable.Rows.Cast<DataRow>().All(row => row.IsNull(col));
            if (removeColumn)
                dataTable.Columns.RemoveAt(col);
        }

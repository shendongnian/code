    DataTable dataTable = GetTable();
    if (dataTable.Rows.Count > 1)
    {
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            var dataRow = dataTable.Rows[i];
            if (dataTable.Rows.Contains(dataRow) && dataTable.Rows.Count != 0)  // Giving error
                continue;
            dataTable.ImportRow(dataRow);
            return dataRow;
        }
    }

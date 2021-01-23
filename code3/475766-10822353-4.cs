    foreach (DataTable table in dataSet.Tables)
    {
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                object item = row[column];
                // read column and item
            }
        }
    }

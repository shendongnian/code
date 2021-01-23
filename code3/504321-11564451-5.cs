    foreach (DataRow souceRow in sourceTable.Rows)
    {
        DataRow destinationRow = destinationTable.Rows.Add();
    
        foreach (DataColumn destinationColumn in destinationTable.Columns)
        {
            string columnName = destinationColumn.ColumnName;
    
            if (sourceTable.Columns.Contains(columnName))
            {
                destinationRow[columnName] = sourceRow[columnName];
            }
        }
     } 

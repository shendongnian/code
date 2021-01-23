    private void ContainColumn(string columnName, DataTable table)
    {
        DataColumnCollection columns = table.Columns;        
        if (columns.Contains(columnName))
        {
           ....
        }
    }

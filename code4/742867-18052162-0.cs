    public void addCol()
    {
        DataColumn column;
        column = new DataColumn(string colName);
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = colName;
        column.Caption = "My header" // ASSIGN HEADERS HERE
        column.ReadOnly = false;
        replaceTableValues.Columns.Add(column);
    }

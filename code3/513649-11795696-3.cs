    DataColumn idColumn = new  DataColumn();
    idColumn.DataType = System.Type.GetType("System.Int32");
    idColumn.ColumnName = "id";
    table.Columns.Add(idColumn);
    //Just if you want define AutoIncrement 
    //idColumn.AutoIncrement = true; 
    DataColumn [] keys = new DataColumn [1];
    keys[0] = idColumn;
    table .PrimaryKey = keys;
    

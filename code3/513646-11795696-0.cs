    DataColumn idColumn = new  DataColumn();
    idColumn.DataType = System.Type.GetType("System.Int32");
    idColumn.ColumnName = "id";
    DataColumn [] keys = new DataColumn [1];
    keys[0] = idColumn;
    table .PrimaryKey = keys;

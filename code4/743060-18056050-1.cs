    DataColumn column = new DataColumn();
    column.DataType = System.Type.GetType("System.Int32");
    column.AutoIncrement = true;
    column.AutoIncrementSeed = 1;
    column.AutoIncrementStep = 1;
    // Add the column to a new DataTable.
    DataTable table = new DataTable("table");
    table.Columns.Add(column);

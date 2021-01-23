    public void AddAutoIncrementColumn(DataTable dt)
    {
        DataColumn column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int32");
        column.AutoIncrement = true;
        column.AutoIncrementSeed = 0;
        column.AutoIncrementStep = 1;
        dt.Columns.Add(column);
        int index = -1;
        foreach (DataRow row in dt.Rows)
        {
            row.SetField(column, ++index);
        }
    }

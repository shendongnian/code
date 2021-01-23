        DataTable table = new DataTable(tableName);
        DataColumn column = new DataColumn("id", typeof(System.Int32));
        column.AutoIncrement = true;
        table.Columns.Add(column);
    
        column = new DataColumn("item", typeof(System.String));
        table.Columns.Add(column);
    
        // Add ten rows.
        DataRow row;
        for (int i = 0; i <= 9; i++)
        {
            row = table.NewRow();
            row["item"] = "item " + i;
            table.Rows.Add(row);
        }
    
        table.AcceptChanges();

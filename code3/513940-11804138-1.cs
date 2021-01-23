        //create table
        DataTable table = new DataTable();
        table.Columns.Add("caliber", typeof(int));
        table.Columns.Add("barrel", typeof(int));
        table.Rows.Add(762, 0);
        table.Rows.Add(556, 0);
        table.Rows.Add(900, 0);
        //delete zero value columns
        List<string> columnsToDelete = new List<string>();
        foreach (DataColumn column in table.Columns) 
            if (IsColumnZero(table, column.ColumnName)) 
                columnsToDelete.Add(column.ColumnName);
        foreach (string ctd in columnsToDelete) table.Columns.Remove(ctd);
        //show results
        GridView1.DataSource = table;
        GridView1.DataBind();

     DataTable dataTable = new DataTable();
        
        // Just add a bunch of columns
        for (int i = 0; i < 15; i++)
        {
        dataTable.Columns.Add("Col" + i.ToString(), typeof
        (string));
        }
        
        // Add a bunch of rows to the DataTable, with some dummy
        values
        for (int i = 0; i < 100; i++)
        {
        DataRow row = dataTable.NewRow();
        for (int j = 0; j < 15; j++)
        {
        row["Col" + j.ToString()] = "Val" + i.ToString() +
        "-" + j.ToString();
        }
        dataTable.Rows.Add(row);
        }
        
        gridView.DataSource = dataTable;
        
        gridView.Rows[1].Frozen = true;
    

    DataTable table = new DataTable();
    table.Columns.Add("x");
    table.Columns.Add("y");
    table.Columns.Add("z");
    
    table.Rows.Add("1", "2", "3");
    table.Rows.Add("1", "2", "3");
    table.Rows.Add("1", "2", "3");
    
    //Move the column 
    table.Columns["z"].SetOrdinal(0);
    
    string value = table.Rows[0][0].ToString();
    //Outputs 3
    
    gridView.DataSource = table;
    gridView.DataBind();

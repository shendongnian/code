    // I suppose you get the connection object as 'con'
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = con;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "...";   // You desired SQL query goes here, or if you want to execute a stored procedure, set the command type as 'StoredProcedure' and text as sp name.
       
    SqlDataAdapter dap = new SqlDataAdapter();
    dap.SelectCommand = cmd;
    DataTable tbl = new DataTable();
    dap.Fill(tbl);
    <br>
    if (tbl.Rows.Count > 0)
    {
        grid.DataSource = tbl;
        grid.DataBind();
    }

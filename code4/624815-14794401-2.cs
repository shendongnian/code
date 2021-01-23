    // I suppose you get the connection object as 'con'<br>
    SqlCommand cmd = new SqlCommand();<br>
    cmd.Connection = con;<br>
    cmd.CommandType = CommandType.Text;<br>
    cmd.CommandText = "...";   // You desired SQL query goes here, or if you want to execute a stored procedure, set the command type as 'StoredProcedure' and text as sp name.<br>
    <br>
    SqlDataAdapter dap = new SqlDataAdapter();<br>
    dap.SelectCommand = cmd;<br>
    DataTable tbl = new DataTable();<br>
    dap.Fill(tbl);<br>
    <br>
    if (tbl.Rows.Count > 0)<br>
    {<br>
        grid.DataSource = tbl;<br>
        grid.DataBind();<br>
    }

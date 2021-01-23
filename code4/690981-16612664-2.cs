    DataTable table = new DataTable();
    using(var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
    {
        table.Load(reader);
    }
    lblDisplay.Text = table.Rows.Count.ToString(); 

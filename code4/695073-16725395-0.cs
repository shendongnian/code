    List<List<string>> pipes = new List<List<string>>();
    NpgsqlDataReader dr = command.ExecuteReader();
    while (dr.Read())
    {
        List<string> pip = new List<string>();
	
        pip.Add("Line:");
	
        for (int i = 0; i < dr.FieldCount; i++)
            pip.Add(dr.GetString(i));
		
        pip.Add("Office");
        TableRow row = new TableRow();
        TableCell cell1 = new TableCell();
        cell1.Text = string.Join(" ", pip);
        row.Cells.Add(cell1);
        docTable.Rows.Add(row);	
        pipes.Add(pip);
    }
    // close DB resources if finished with them
    dr.close();
    pgconn.close();

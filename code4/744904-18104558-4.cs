    var q = from c in this.DataGridView1.Columns.Cast<DataGridViewColumn>()orderby c.DisplayIndex select c;
    foreach (DataGridViewColumn column in q) 
    {
        if (column.Visible == true) 
        {
		Console.WriteLine(column.HeaderText.ToString());
	    }
    }

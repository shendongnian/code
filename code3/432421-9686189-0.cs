    foreach (DataGridViewColumn col in DataGridView1.Columns) 
    {
	    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
	    col.Width = 5;
    }
    foreach (DataGridViewRow row in DataGridView1.Rows) 
    {
    	row.Height = 5;
    }

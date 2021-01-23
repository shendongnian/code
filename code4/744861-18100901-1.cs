    static DataTable ConvertListToDataTable(List<string[]> list)
	{
	    // New table.
	    DataTable table = new DataTable();
	    // Get max columns.
	    int columns = 0;
	    foreach (var array in list)
	    {
		    if (array.Length > columns)
		    {
		        columns = array.Length;
		    }
	    }
	    // Add columns.
	    for (int i = 0; i < columns; i++)
	    {
		    table.Columns.Add();
	    }
	    // Add rows.
	    foreach (var array in list)
	    {
		    table.Rows.Add(array);
	    }
	    return table;
	}
    protected void Button1_Click(object sender, EventArgs e)
    {  
        List<string[]> list = new List<string[]>();
        list.Add(new string[] { "Column 1", "Column 2", "Column 3" });
        list.Add(new string[] { "Row 2", "Row 2" });
        list.Add(new string[] { "Row 3" });
    
        // Convert to DataTable.
        DataTable table = ConvertListToDataTable(list);
        dataGridView1.DataSource = table;
    }

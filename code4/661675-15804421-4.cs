    string arrayUp = "ABBAAAABABAAAB"; // Example value for rtb_up.Text
    string arrayDown = "ABABAAABAB"; // Example value for rtb_down.Text
    DataTable dataTable = new DataTable();
    // Add variable number of columns, depending on the length of arrayUp
    for (int i = 0; i < arrayUp.Length; i++)
    	dataTable.Columns.Add("");
    // Iterate through the "rows" first
    for (int i = 0; i < arrayDown.Length; i++)
    {
    	DataRow dataRow = dataTable.NewRow();
    
    	// Then iterate through the "columns"
    	for (int j = 0; j < arrayUp.Length; j++)
    	{
    		if (arrayDown[i] == arrayUp[j])
    			dataRow[j] = "+";
    		else
    			dataRow[j] = "-";
    	}
    
    	dataTable.Rows.Add(dataRow);
    }
    dgv_main.AutoGenerateColumns = true;
    dgv_main.DataSource = dataTable;

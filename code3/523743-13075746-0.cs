    int RowCount = 12; 
    Dictionary<int, string> PlatypusPairs;
    
    . . .
    
    private void button3_Click(object sender, EventArgs e) {
    	// Retrieve data as dictionary 
    	PlatypusPairs = InterpSchedData.GetAvailableForPlatypusAndDate(oracleConnectionTestForm, 42, DateTime.Today.Date);
    	int ColumnCount = 16;
    	// Add the needed columns
    	for (int i = 0; i < ColumnCount; i++) {
    		string colName = string.Format("Column{0}", i + 1);
    		dataGridView1.Columns.Add(colName, colName); 
    	}
    
    	for (int row = 0; row < RowCount; row++) {
    		// Save each row as an array
    		string[] currentRowContents = new string[ColumnCount];
    		// Add each column to the currentColumn
    		for (int col = 0; col < ColumnCount; col++) {
    			currentRowContents[col] = GetValForCell(row, col);
    		}
    		// Add the row to the DGV
    		dataGridView1.Rows.Add(currentRowContents);
    	}
    }
    
    private string GetValForCell(int Row, int Col) {
    	string retVal;
    
    	if (Col % 2 == 0) {
    		retVal = GetTimeStringForCell(Row, Col);
    	} else {
    		retVal = GetPlatypusStringForCell(Row, Col);
    	}
    	return retVal;
    }
    
    private string GetTimeStringForCell(int Row, int Col) {
    	const int TIME_INCREMENT_STEP = 15;
    	var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
    	dt = dt.AddMinutes(((Col * (RowCount / 2)) + Row) * TIME_INCREMENT_STEP);
    	return dt.ToString("HH:mm");
    }
    
    private string GetPlatypusStringForCell(int Row, int Col) {
    	int multiplicand = Col / 2;
    	string val = string.Empty;
    	int ValToSearchFor = (multiplicand * RowCount) + (Row + 1);
    	if (PlatypusPairs.ContainsKey(ValToSearchFor)) {
    		PlatypusPairs.TryGetValue(ValToSearchFor, out val);
    		if (val.Equals(0)) {
    			val = string.Empty;
    		}
    	}
    	return val;
    }

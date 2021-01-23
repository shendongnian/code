    void Main() {
    	var dt = GetDataTable("Sales");
    	dt.Dump();
    	UnpivotDataTable(dt).Dump();
    }
   
    public DataTable GetDataTable(string name) {
    	var dt = new DataTable(name);	
    	dt.Columns.Add("Id", typeof(string)); // dt.Columns.Add("Id", typeof(int));	
    	dt.Columns.Add("Apartement", typeof(string));	
    	dt.Columns.Add("Monday", typeof(int));
    	dt.Columns.Add("Tuesday", typeof(int));
    	dt.Columns.Add("Wednesday", typeof(int));
    	dt.Columns.Add("Thursday", typeof(int));
    	dt.Columns.Add("Friday", typeof(int));		
    	dt.Rows.Add(1, "Food", 300, 270, 310, 280, 500);
    	dt.Rows.Add(2, "Electronics", 600, 470, 410, 380, 1500);	
    	return dt;
    }
    
    public DataTable UnpivotDataTable(DataTable dt){
    	string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();  			
    	var dt2 = new DataTable("unpivot");	
    	dt2.Columns.Add("Headers", typeof(string)); 
    	for(int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++){
    		dt2.Columns.Add("Row" + rowIndex.ToString(), typeof(string)); 
    	}
    	
    	for(int i=0; i < columnNames.Length; i++){
    		// flaw: hardcoded is the amount of rows that are unpivoted
    		dt2.Rows.Add(columnNames[i], dt.Rows[0].ItemArray[i],dt.Rows[1].ItemArray[i]);
    	}
    	return dt2;
    }

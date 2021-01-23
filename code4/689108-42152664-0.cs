    var dataSet = new DataSet();
    var filterDataTable = new DataTable();
    //get all the selection of MultiDropDown and seperated them by comas..
    string selectedValues = string.Join(", ", chkMultiSelection.Items.Cast<ListItem>().Where(x => x.Selected).Select(x => x.Text));
    
    //convert your multiselection to array
    string[] multiValues = selectedValues.Split(',');
    
    //iterate through them and filter the data based on selection. That will filter the rows which don't contain the selection
    foreach (string s in multiValues)
    {
    	IEnumerable<DataRow> datarow = default(IEnumerable<DataRow>);
    	datarow = dt.AsEnumerable().Where(x => x.Field<string>("ColumnName") == s.Trim());
    	if (datarow.Count() > 0)
    	{
    		filterDataTable = datarow.CopyToDataTable(); 
    		
    		//use dataset and store each filter data
    		dataSet.Tables.Add(filterDataTable);
    
    	}
    }
 
    

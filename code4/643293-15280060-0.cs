    public DataTable PrepareDataTable(DataTable dtResults)
    {
    	string[] subCategories = new string[3] {"Critical Down Time", "Critical Outage", "Total Repair Time"};
    	//make a copy of the original table
    	DataTable dtOutput = dtResults.Clone();
    	DataRow drOutput = null;
    	DataRow[] drResults = null;
    	//retrieve the list of Categories
    	var categories = dtResults.AsEnumerable().Select(r => r["Category"]).Distinct().ToList();
    	//populate the new table with the appropriate rows (combinations of categories/subcategories)
    	foreach (string category in categories)
    	{
    		for (int i = 0; i < subCategories.Length	; i++)
    		{
    			//create the new row in the new table
    			drOutput = dtOutput.NewRow();
    			drOutput["Category"] = category;
    			drOutput["SubCategory"] = subCategories[i];
    			//here is where you will check to see if a row with the same category and subcategory exists in dtResults. if it does, then copy over the values for each column
    			drResults = dtResults.Select(String.Format("Category = '{0}' AND SubCategory = '{1}'", category, subCategories[i]));
    			if(drResults.Length > 0)
    			{
    				foreach(DataColumn column in dtResults.Columns)
    				{
    					drOutput[column.ColumnName] = drResults[0][column.ColumnName];
    				}
    				
    			}
    			dtOutput.Rows.Add(drOutput);
    		}
    		//add filler/spacer row
    		drOutput = dtOutput.NewRow();
    		dtOutput.Rows.Add(drOutput);
    	}
    	return dtOutput;
    }

    public void RunTest()
    {
    	DataTable dtResults = new DataTable();
    	dtResults.Columns.Add("Category");
    	dtResults.Columns.Add("SubCategory");
    	dtResults.Rows.Add("XXXX", "Critical Down Time");
    	dtResults.Rows.Add("XXXX", "Critical Outage");
    	dtResults.Rows.Add("XXXX", "Total Repair Time");
    	dtResults.Rows.Add("YYYY", "Critical Down Time");
    	dtResults.Rows.Add("YYYY", "Critical Outage");
    	dtResults.Rows.Add("ZZZZ", "Critical Down Time");
    	dtResults.Rows.Add("ZZZZ", "Critical Outage");
    	dtResults.Rows.Add("ZZZZ", "Total Repair Time");
    	dtResults.Rows.Add("AAAA", "Critical Down Time");
    
    	PrepareDataTable(dtResults);
    }

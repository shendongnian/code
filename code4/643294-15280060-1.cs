    public void RunTest()
    {
    	DataTable dtResults = new DataTable();
    	dtResults.Columns.Add("Category");
    	dtResults.Columns.Add("SubCategory");
    	dtResults.Columns.Add("Data");
    	dtResults.Rows.Add("00000A", "Critical Down Time", "1");
    	dtResults.Rows.Add("00000A", "Critical Outage", "1");
    	dtResults.Rows.Add("00000A", "Total Repair Time", "1");
    	dtResults.Rows.Add("00000B", "Critical Down Time", "1");
    	dtResults.Rows.Add("00000B", "Total Repair Time", "1");
    	dtResults.Rows.Add("00000C", "Critical Down Time", "1");
    	dtResults.Rows.Add("00000C", "Critical Outage", "1");
    	dtResults.Rows.Add("00000C", "Total Repair Time", "1");
    	dtResults.Rows.Add("00000D", "Critical Down Time", "1");
    	dtResults.Rows.Add("00000E", "Critical Down Time", "1");
    	dtResults.Rows.Add("00000G", "Critical Down Time", "1");
    	dtResults.Rows.Add("00000M", "Critical Down Time", "1");
    	dtResults.Rows.Add("00000M", "Critical Outage", "1");
    	dtResults.Rows.Add("00000M", "Total Repair Time", "1");
    	DataTable dtOutput = PrepareDataTable(dtResults);
    }

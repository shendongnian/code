    private static string _dbJobSelect = "SELECT jID, jAddress FROM Job";
    
    public static DataTable GetJobs(string jAddress)
    {
    	DataTable dt = ExecuteDataTable(_dbJobSelect);
    
    	if (!string.IsNullOrEmpty(jAddress))
    	{
    		DataView dv = dt.DefaultView;
    		dv.RowFilter = string.Format("jAddress = '{0}'", jAddress);
    		dt = dv.Table;
    	}
    
    	return dt;
    }

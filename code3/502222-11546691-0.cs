    protected void ldsData_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
    	var result = db.INSTRUMENT_LOOP_DESCRIPTIONs.AsQueryable();
    
    	foreach (string key in Request.QueryString.Keys)
    	{
    		if (Request.QueryString[key].Trim() != "")
    		{
    			result = result.WhereLike(key, Request.QueryString[key].Replace("?", "_").Replace("*", "%"));
    		}
    	}
    
    	e.Result = result;
    }

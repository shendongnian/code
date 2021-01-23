    /// <summary>
    /// Get Data
    /// </summary>
    /// <returns>data</returns>
    public static ElementOut GetData()
    {
    	//function return value
    	ElementOut functionReturnValue = new ElementOut();
    
    	try
    	{
    		string key = "data";
    		if (HttpRuntime.Cache[key] == null)
    		{
				//fetch data
    			var data = CreateBLLAdapter().GetData();
    
				//validate data
    			if (data == null) throw new Exception("data is empty!");
    
    			//set cache to 12 hours
    			DateTime timeToExpire = DateTime.Now.AddHours(12);
    
    			//set cache
    			HttpRuntime.Cache.Insert(key, data, null, timeToExpire, Cache.NoSlidingExpiration);
    		}
    
    		//set return from cache
    		functionReturnValue = (ElementOut)HttpRuntime.Cache[key];
    		
    	}
    	catch (Exception ex)
    	{
    		//Log.WriteServerErrorLog(ex);
    	}
    
    	return functionReturnValue;
    }

    const string cArrNameConst = "cArr_cnst";
    
    public string[] cArrKeepNames
    {
    	set
    	{
    		ViewState[cArrNameConst] = value;
    	}
    	get
    	{
    		if (!(ViewState[cArrNameConst] is string[]))
    		{
    			// need to fix the memory and added to viewstate
    			ViewState[cArrNameConst] = new string[5];
    		}
    
    		return (string[])ViewState[cArrNameConst];
    	}
    }

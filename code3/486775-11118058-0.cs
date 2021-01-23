    public void LogActivity(Func<string> activity)
    {
    	if (_isActive)
    	{
    		string log = activity();
    		// save 'log' to database
    	}
    }

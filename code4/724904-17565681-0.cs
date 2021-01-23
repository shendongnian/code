    bool isDateTimeValid(string date, string format)
    {
    	try
    	{
    		DateTime outDate = new DateTime();
    		DateTime.ParseExact(...);
    		
    		return true;
    	}
    	catch(Exception exc)
    	{
    		return false;
    	}
    }

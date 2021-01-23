    bool isDateTimeValid(string date, string format)
    {
    	try
    	{
    		DateTime outDate = DateTime.ParseExact(date, format, Thread.CurrentThread.CurrentUICulture);
    		
    		return true;
    	}
    	catch(Exception exc)
    	{
    		return false;
    	}
    }

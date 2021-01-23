    public void Main()
    {
    	Console.WriteLine(
    		ConvertJsDate("Fri Apr 18 2014 16:23:18 GMT-0500 (Central Daylight Time)"));
        //test more regular date
        Console.WriteLine(
    		ConvertJsDate("4/18/2014 16:23:18")); 
    }
    
    public DateTime ConvertJsDate(string jsDate)
    {
    	string formatString = "ddd MMM d yyyy HH:mm:ss";
    	
    	var gmtIndex = jsDate.IndexOf(" GMT");
    	if (gmtIndex > -1) 
    	{
    		jsDate = jsDate.Remove(gmtIndex);
    		return DateTime.ParseExact(jsDate, formatString, null);
    	}
    	return DateTime.Parse(jsDate);
    }

    using(WebClient client = new WebClient())
    {
    	string pageData;
    	try
    	{
    		pageData = client.DownloadString(yourAddress);
    	}
    	catch(Exception e)
    	{
    		//something went wrong. Maybe the site is down?
    	}
    	//does pageData have expected content?
    }

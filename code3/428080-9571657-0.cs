    Stream stream = null;
    
    while (stream == null)
    {
    	try
    	{
    		HttpWebResponse resp = (HttpWebResponse)myReq.GetResponse();
    		stream = resp.GetResponseStream();
    	}
    	catch (Exception e)
    	{
    		System.Threading.Thread.Sleep(500);
    		
    		// plus idea: die after a few try?
    	}
    }

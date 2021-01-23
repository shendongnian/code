    internal bool WebServiceAvailable()
    {
    	bool Result = false;
    	string Url = {ENTER URL}
    	try
    	{
    		HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(Url);
    		Req.Timeout = 3000;
    
    		using (HttpWebResponse Rsp = (HttpWebResponse)Req.GetResponse())
    		{
    			if (Rsp.StatusCode == HttpStatusCode.OK)
    			{
    				Result = true;   
    			}
    		}
    	}
    	catch (WebException) { }
    
    	return Result;
    }
    if (!WebServiceAvailable() 
    {
        //Redirect to Not Available page
    }

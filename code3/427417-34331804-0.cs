    public ActionResult Index()
    {
    	if("GET"==this.HttpContext.Request.RequestType)
        {
    		Some Code--Some Code---Some Code for GET
    	}
    	else if("POST"==this.HttpContext.Request.RequestType)
    	{
    		Some Code--Some Code---Some Code for POST
    	}
    	else
    	{
    		//exception
    	}
    	
    	return View();
    }

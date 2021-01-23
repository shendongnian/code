     protected void Application_BeginRequest(object sender, EventArgs e)
     {
        string section = Request.RequestContext.RouteData.Values["databaseSection"].ToString();
    	if(section == sectionName2)
    	{
    		do some stuff to configure your database session 
    	}
        else
    	{
    		default behavior
    	}
     }

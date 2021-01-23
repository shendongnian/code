         protected void Application_Error(object sender, EventArgs e)
    {
    	Exception ex = Server.GetLastError();
    	if (ex is HttpException)
    	{
    		if (((HttpException)(ex)).GetHttpCode() == 404)
    			Server.Transfer("~/404.aspx");
    	}
    	Server.Transfer("~/AnyOtherError.aspx");
    }

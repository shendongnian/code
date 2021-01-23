	protected void Application_BeginRequest(object sender, EventArgs e)
	{
		if(MyGlobalFlags.TrackingRequests){
			//	do stuff
		}
	}
	protected void Application_EndRequest(object sender, EventArgs e)
	{
		if(MyGlobalFlags.TrackingRequests){
			//	do stuff
		}
	}

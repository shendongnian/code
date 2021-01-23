    protected void Page_Load(object sender, EventArgs e)
    {
    	// Check if we received a POST value with name 'action'
    	string action = Request["action"];
    	if(action != null)
    	{
    		// It's an AJAX Call
    		if(action == "deleteEvent")
    		{
    			// At this point we should expect a POST value with name 'id'
    			int id = int.Parse(Request["id"]);
    			// Execute action
    			DoActionDeleteEvent(id);
    			// Do nothing else since it's an AJAX call
    			return;
    		}
    	}
    	
    }
    
    private void DoActionDeleteEvent(int id)
    {
    	Response.ContentType = "text/plain";
    	try
    	{
    		// ToDo: Delete the event from the database
    		// All went well, write 0 in the response.
    		Response.Write("0");
    	}
    	catch
    	{
    		// There was an error, write 1 in the response
    		Response.Write("1");
    	}
    	// End the response
    	Response.End();
    }

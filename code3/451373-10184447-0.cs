    public void Session_OnEnd()
    {
    	// You need some identifier unique to the user's session
    	if (Cache["userID"] != null)
    		Cache.Remove("userID");
    }

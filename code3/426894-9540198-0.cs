    FacebookClient fbClient = new FacebookClient(accessToken);  
    parameters = new Dictionary<string, object> { 
    	{ "message", "hi! this is my status message" },
    	{ "place", new Dictionary<string, object> { 
    		{ "id", "facebook_id_of_place" }, 
    		{ "name", "name_of_facebook_place" }
    	}
    };
    fbClient.Post("me/feed", parameters);

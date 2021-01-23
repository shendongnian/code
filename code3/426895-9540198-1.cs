    FacebookClient fbClient = new FacebookClient(accessToken);  
    parameters = new Dictionary<string, object> { 
    	{ "message", "hi! this is my status message" },
    	{ "place", "facebook_id_of_place" }
    };
    fbClient.Post("me/feed", parameters);

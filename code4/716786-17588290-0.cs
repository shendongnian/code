		var fb = new FacebookClient(App.AccessToken);		
	
		var parameters = new Dictionary<string, object>();
		parameters["name"] = "Description for the pic";
		parameters["TestPic"] = new FacebookMediaObject
		{
			ContentType = "image/jpeg",
			FileName = "photo_name.jpg"
	
		}.SetValue(File.ReadAllBytes(Server.MapPath("~\\Images\\photo_name.jpg")));
	
		dynamic res = fb.Post("me/Photos", parameters);
	
		// res.id contains the returned photo id

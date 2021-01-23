    var fbApplication = new DefaultFacebookApplication { AppId = fbapp, AppSecret = fbsec };
                var current = new FacebookWebContext(fbApplication);
    
                Facebook.Web.FacebookWebClient client = new Facebook.Web.FacebookWebClient(token);
                //client.AccessToken = current.AccessToken;   
                dynamic parameters = new ExpandoObject();
                parameters.message = "";
                parameters.link = link;
                parameters.name = name;
                parameters.caption = caption;
                parameters.description = desc;
                parameters.from = fromId;//your fb ID
    //friendId will be the ID of the person,you wants to post on wall
                object resTest = client.Post("/" + friendId + "/feed", parameters);

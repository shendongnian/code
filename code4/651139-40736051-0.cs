     string app_id = "*************";
    string app_secret = "*************";
    string scope = "publish_actions,manage_pages";
    string accessToken = GetAccessToken(FacebookAppId, FacebookAppSecret);
                if (Request["code"] == null)
                {
    Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",app_id, Request.Url.AbsoluteUri, scope));
                }
                else
                {
                    FacebookClient fb = new FacebookClient();
                    dynamic result1 = fb.Get("oauth/access_token", new
                    {
                        client_id = "******",
                        client_secret = "*************",
                        grant_type = "publish_actions,manage_pages",
                        redirect_uri = "*************"
                    });
    
                    fb.AppId = "MY_APP_ID";
                    fb.AppSecret = "MY_SECRET_ID";
                    fb.AccessToken = result1.access_token;
    // to make new object
                    dynamic parameters = new ExpandoObject();
                    parameters.message = "Check out this funny article";
                    parameters.link = "*************";
                    parameters.picture = "*************";
                    parameters.name = "*************";
                    parameters.caption = "*************";
                    parameters.description = "*************";
                    parameters.req_perms = "*************";
                    parameters.scope = "*************";
    
                    parameters.actions = new
                    {
                        name = "*************",
                        link = "*************",
                    };
                    parameters.privacy = new
                    {
                        value = "*************",
                    };
    
                    try
                    {
                        var result = fb.Post("/" + "*************" + "/feed", parameters);
                    }
                    

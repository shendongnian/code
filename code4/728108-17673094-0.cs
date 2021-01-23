    //following code will not work, although option is given
    var extraData= new Dictionary<string, object>();
            extraData.Add("scope",
                                   "email,publish_actions,create_event");
            //facebookSocialData.Add("perms", "status_update");
            OAuthWebSecurity.RegisterFacebookClient(
                 "xxxx",
                 "yyyy", "Facebook", extraData);

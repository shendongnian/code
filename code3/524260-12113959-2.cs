    string accessToken = "";
    FacebookWebClient fbApp = new FacebookWebClient();
                
    dynamic parametersForToken = new ExpandoObject();
    parametersForToken.fields = "access_token";
    try
    {
      dynamic me = fbApp.Get(idExternalPage, parametersForToken);
      accessToken = me.access_token;
    }
    catch (Exception ex)
    {
        return;
    }
    FacebookClient facebookClient = new FacebookClient(accessToken);
    var albumParameters = new Dictionary<string, object>();
    albumParameters["message"] = "new message";
    albumParameters["name"] = "new name";
    facebookClient.Post("/me/albums", albumParameters);
    

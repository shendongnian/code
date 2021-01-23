    public JsonServiceClient GetAuthenticatedClient()
        {
            //Need to get an authenticated session key/token from somewhere
            //this can be used when MVC and ServiceStack are running together-> var sessionKey = SessionFeature.GetSessionKey().Replace("urn:iauthsession:", ""); 
            //maybe add the key/token to a Session variable after your first successful authentication???
            var sessionKey = Session["someKey"]
            
            var client = new JsonServiceClient("http://" + HttpContext.Request.Url.Authority + "/api")
            {
                LocalHttpWebRequestFilter = (r) =>
                {
                    var c = new CookieContainer();
                    c.Add(new Uri("http://" + HttpContext.Request.Url.Authority + "/api"), new Cookie() { Name = "ss-id", Value = sessionKey });
                    r.CookieContainer = c;
                }
            };
            return client;
        }
     
    

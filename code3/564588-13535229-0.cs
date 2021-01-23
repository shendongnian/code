    public ActionResult Login()
    		{
    			var requestToken = service.GetRequestToken(CallBackURL);
    
    			var url = service.GetAuthenticationUrl(requestToken);
    
    			return Redirect(url.ToString());
    		}

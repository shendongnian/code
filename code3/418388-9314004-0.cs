    public void CreateCookie()
    {
    	HttpCookie cookie = new HttpCookie(mConfig.webCookie);
    	TimeSpan span = new TimeSpan(0, 0, 30, 0);
    	DateTime time = DateTime.Now; ;
    
    	cookie["Username"] = mEncrypt.Encrypt(mUser.Username);
    	cookie.Domain = "mydomian.com";
    
    	cookie.Expires = time + span;
    
    	HttpContext.Current.Response.Cookies.Add(cookie);
    }
    
    public void UpdateCookie()
    { 
    	TimeSpan span = new TimeSpan(0, 0, 30, 0);
    	DateTime time = DateTime.Now;
    
    	HttpCookie cookie = HttpContext.Current.Request.Cookies[mConfig.webCookie];
    	
    	// without specifying the domain the cookie will be set with the subdomain
    	cookie.Domain = "mydomain.com";
    	HttpContext.Current.Response.Cookies.Set(cookie);
    	
    	HttpContext.Current.Response.Cookies[mConfig.webCookie].Expires = time + span;
    }

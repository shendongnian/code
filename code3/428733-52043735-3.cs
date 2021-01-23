    Cookie SessionCookie = new Cookie("{CookieName}", {Cookievalue})
    {
        Domain = "{domain you want to hit}", Path = "/", Expired = false, HttpOnly = true 
    };
    
    CookieContainer SessionCookieHolder = new CookieContainer();
    
    SessionCookie.Add(SessionCookie);
    
    try
    {
       HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("{URL}");
       WebReq.CookieContainer = SessionCookie;
       WebReq.Method = "GET/POST/HEAD"; //depending on the request type//
       WebReq.KeepAlive = true;
       HttpWebResponse Resp = (HttpWebResponse)WebReq.GetResponse();
    }
    
    catch(Exception ex)
    
    {
       string ExceptionReader = ex.Message;
    }

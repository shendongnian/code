    public string GetCookieValueOrDefault(string cookieName)
    {
       HttpCookie cookie = Request.Cookies[cookieName];
       if(cookie == null)
       {
          return "";
       }  
       return cookie.Value;
    }

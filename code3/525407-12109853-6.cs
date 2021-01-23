    public static string GetValueOrDefault(this HttpCookie cookie)
    {
       if(cookie == null)
       {
          return "";
       }  
       return cookie.Value;  
    }

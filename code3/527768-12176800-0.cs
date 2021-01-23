    DeleteCookie("ReferedCookie");
    
    
    public void DeleteCookie(string Name) 
    {
        if (System.Web.HttpContext.Current.Request.Cookies[Name] != null)
        {
            HttpCookie myCookie = new HttpCookie(Name);
            myCookie.Expires = DateTime.Now.AddDays(-5d);
            System.Web.HttpContext.Current.Response.Cookies.Add(myCookie);
        }        
    }

    string cookieName;
        int limit = Request.Cookies.Count;
        
        for (int i = 0; i < limit; i++)
        {
            cookieName = Request.Cookies[i].Name;
            var cookie = new HttpCookie(cookieName);
            cookie.Value = "";
            cookie.Expires = DateTime.Now.AddDays(-3);
            //Only if HTTPS
            cookie.Secure = true;
            //Only if a domain is specified, and obviously, it should match the domain of the app
            cookie.Domain = "XYZ";
            Response.Cookies.Add(cookie);
        }
        FormsAuthentication.SignOut();
        Response.Redirect("/default.aspx");

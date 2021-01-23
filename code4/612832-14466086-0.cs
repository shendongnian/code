    void Application_BeginRequest(object sender, EventArgs e)
    {
        try
        {
            string session_param_name = "ASPSESSID";
            string session_cookie_name = "ASP.NET_SESSIONID";
            string session_value = Request.Form[session_param_name] ?? Request.QueryString[session_param_name];
            if (session_value != null) { UpdateCookie(session_cookie_name, session_value); }
        }
        catch (Exception) { }
    }
    
    void UpdateCookie(string cookie_name, string cookie_value)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
        if (cookie == null)
        {
            HttpCookie cookie1 = new HttpCookie(cookie_name, cookie_value);
            Response.Cookies.Add(cookie1);
        }
        else
        {
            cookie.Value = cookie_value;
            HttpContext.Current.Request.Cookies.Set(cookie);
        }
    }

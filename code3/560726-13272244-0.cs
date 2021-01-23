    string name = "myCookie";
    HttpContext context = ((HttpApplication)sender).Context;
    HttpCookie cookie = null;
    if (context.Response.Cookies.AllKeys.Contains(name))
    {
        cookie = context.Response.Cookies[name];
    }
    if (cookie != null)
    {
        // update response cookie
    }

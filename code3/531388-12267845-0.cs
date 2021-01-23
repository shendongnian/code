    string cookieName = "loginidcookie";
    if (Request.Cookies[cookieName ] != null)
    {
        var myCookie = new HttpCookie(cookieName);
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
    }
    Response.Redirect("logout.aspx", false);

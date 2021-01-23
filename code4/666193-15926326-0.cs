    if (Request.Cookies["OptDepth"] != null)
    {
        HttpCookie myCookie = new HttpCookie("OptDepth");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
    }

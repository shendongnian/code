    if (Request.Cookies["dcart"] != null)
    {
       HttpCookie myCookie = new HttpCookie("dcart");
       myCookie.Expires = DateTime.Now.AddDays(-1d);
       myCookie.Path = "/store";
       Response.Cookies.Add(myCookie);
    }

    public void Application_BeginRequest()
    {
            myCookie = new HttpCookie("UserSettings");
            myCookie.Value = "nl";
            myCookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(myCookie);
    }

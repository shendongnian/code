    if (Request.Cookies["MyTestCookie"] == null)
    {
        HttpCookie myCookie = new HttpCookie("MyTestCookie");
        myCookie.Path = "/";
        myCookie.Domain = "domain.com";
        myCookie.Value = "Hi";
        myCookie.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Add(myCookie);
    
        lblErr.Text = "Cookie was null.";
    }
    else
    {
        lblErr.Text = Request.Cookies["MyTestCookie"].Value;
    }

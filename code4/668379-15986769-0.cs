    protected void Session_Start(Object sender, EventArgs e)
    {
        var session = HttpContext.Current.Session;
    
        session["IPAddress"] = Request.UserHostAddress;
        session["LoginTime"] = DateTime.Now;
    
        // you'll need to plug in here how you're going to determine this
        session["LoginPlace"] = "something";
    }

    protected void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        if (HttpContext.Current.Session["DETAILS"] != null)
        {
            HttpContext.Current.Session["DETAILS"] = "[type here your data]";
        }
    }

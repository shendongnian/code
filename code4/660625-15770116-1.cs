    void Session_Start(object sender, EventArgs e)
    {
        if (Session.IsNewSession)
            Response.RedirectToRoute("LogOn", "User");
    }

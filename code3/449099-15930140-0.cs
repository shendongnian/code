    protected void Session_Start(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Session["Name"] = client.GetName(User.Identity.Name);   
        }
    }

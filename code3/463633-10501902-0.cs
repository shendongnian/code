    protected void Session_Start(object sender, EventArgs e)
    {
        if (this.Context.User != null && this.Context.User.Identity != null
            && this.Context.User.Identity.IsAuthenticated)
        {
            // Got user from authentication cookie (remember me).
            // here you can either re-instantiate user in your application/session
            // so he/she will be logged-in automatically (which is remember me functionality)
            // The username is in this.Context.User.Identity.Name
            // Or redirect user to login page if you need manual login
        }
    }

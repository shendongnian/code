    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var user = ticket.Name;
            var identity = new GenericIdentity(user, "Forms");
            var principal = new GenericPrincipal(identity, null);
            Context.User = principal;
        }
    }

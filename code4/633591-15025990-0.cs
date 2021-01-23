    private void RedirectToProperPage(params string[] roles)
    {
        foreach (string role in roles)
        {
            if (Roles.IsUserInRole(role))
                Response.Redirect(String.Format("~/{0}.aspx", role));
        }
    }

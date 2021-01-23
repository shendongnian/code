    protected void cmdLogout_click(object sender, EventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("~/static/loggedOut.htm"); // Added, can self close if needed in the HTML
    }

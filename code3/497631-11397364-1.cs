    void Application_Error(object sender, EventArgs e)
    {
        string host = Context.Request.Url.Host;
        string redirectUrl = string.Format("~/Error.html?aspxerrorpath={0}&aspxerrorhost={1}", Server.UrlEncode(Context.Request.Path), Server.UrlEncode(host));
        Response.Redirect(redirectUrl);
    }

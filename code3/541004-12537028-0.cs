    protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext.Current.Cache["error:" + Session.SessionID] = Server.GetLastError();
            Response.Redirect("Error.aspx");
        }

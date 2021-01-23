    Session.Abandon();
    Session["SessionName"] = null;
    Session.Clear();
    
    Then Write Code in Global.asax File
    
    Void Application_Error(object sender,EventArgs e)
    {
         Response.Redirect("LogIn.aspx");
    
         or
    
         Server.Transfer("LogIn.aspx");
    }

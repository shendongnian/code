    void Application_Error(object sender, EventArgs e) 
    {    
        Session["error"] = Server.GetLastError().InnerException; 
    }
    void Session_Start(object sender, EventArgs e) 
    {      
        Session["error"] = null;
    }

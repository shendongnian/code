     // Define the name and type of the client scripts on the page.
     const String csname1 = "MyScriptName";
     Type cstype = this.GetType();
    
     // Get a ClientScriptManager reference from the Page class.
     ClientScriptManager cs = Page.ClientScript;
     
     // Check to see if the startup script is already registered.
     if (!cs.IsStartupScriptRegistered(cstype, csname1))
     {
          StringBuilder cstext1 = new StringBuilder();
          cstext1.Append("<script> var myVariable = true; </");
          cstext1.Append("script>");
    
          cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
      }

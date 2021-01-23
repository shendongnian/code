    <%@ Application Language="C#" %>
    
    <script runat="server">
    
        void Application_Start(object sender, EventArgs e) 
        {
           Application.Add("Visitor",0);
          HttpContext.Current.Response.Redirect("Default.aspx");
            // Code that runs on application startup
            //string MyCounter = ConfigurationManager.AppSettings["Counter"];
            //Application.Add("Count",MyCounter);
           // Counter.UpdateAddOneRecord("VisitorCounter");
        }
        
        void Application_End(object sender, EventArgs e) 
        {
            //  Code that runs on application shutdown
          //  ConfigurationManager.AppSettings["Counter"] = Application["Count"].ToString();
            
    
        }
            
        void Application_Error(object sender, EventArgs e) 
        { 
            // Code that runs when an unhandled error occurs
    
        }
    
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            int visitor = int.Parse(Application.Get("Visitor").ToString());
            visitor++;
            Application.Set("Visitor", visitor);
            Counter.UpdateAddOneRecord("VisitorCounter");
            // Arabic
            //Session.Add("Lng", "ar-IQ");
            //Session.Add("Theme", Neaimy_MSB.Neaimy_Lib.getTheme());
            //Session.Add("MrqDir", "Left");
            //Session.Add("Dir", "rtl");
            //Session.Add("MrqDirInverse", "ltr");
            //Session.Add("AddComment", "flase");
    
            //Session.Add("Lng", "ar-IQ");
            Session.Add("Lng", "en-GB");
            Session.Add("Theme", Neaimy_MSB.Neaimy_Lib.getTheme());
            Session.Add("MrqDir", "Right");
            Session.Add("Dir", "ltr");
            Session.Add("MrqDirInverse", "rtl");
            Session.Add("AddComment", "flase");
    
            //  int count =int.Parse(Application.Get("Count").ToString());
            //int count =int.Parse(Application.Get("Count").ToString());
            //count++;
            //Application.Set("Count",count);
        }
    
        void Session_End(object sender, EventArgs e) 
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            int Visitor = int.Parse(Application.Get("Visitor").ToString());
            Visitor--;
            Application.Set("Visitor", Visitor);
          
    
        }
           
    </script>

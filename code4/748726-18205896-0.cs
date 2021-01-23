    void Application_BeginRequest(object sender, EventArgs e)
    {
         if (HttpContext.Current.Request.Url.AbsoluteUri.Equals("http://www.example.com/foo.aspx")) 
         { 
            string newUrl = "http://www.example.com"; 
            Response.Status = "301 Moved Permanently"; 
            Response.StatusCode = 301; 
            Response.StatusDescription = "Moved Permanently";  
            Response.AddHeader("Location", newUrl); 
            Response.End();
         }
    }
        

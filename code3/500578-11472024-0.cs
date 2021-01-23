    void Application_BeginRequest(object sender, EventArgs e)
    {
        // Get the current path
        string CurrentURL = Request.Url.ToString();
         // Condition
        if (CurrentURL.Contains("HtmlResponce.aspx"))
        {
            HttpContext MyContext = HttpContext.Current;
         
            // Re write here
            MyContext.RewritePath("testPage.aspx");
        }
    }

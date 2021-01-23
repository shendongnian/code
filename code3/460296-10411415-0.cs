    void Application_BeginRequest(object sender, EventArgs e)
    {
        string path = Request.Path.ToLower();
        if (ContainsUpperChars(path))
        {
            HttpContext.Current.Response.Redirect(Request.Path.ToLower());
        }
    }
    
    bool ContainsUpperChars(string str) { some code to test for uppercase chars }

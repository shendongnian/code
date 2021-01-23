    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        string file_path = Request.RawUrl.ToLower();
        char[] separator = new char[] { '/' };
        string[] parts = file_path.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length > 0 && parts[0] == "fr")
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
            Context.RewritePath("~/" + file_path.Substring(4), true);
        }
        else
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
        }
    } 

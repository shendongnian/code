    void Application_BeginRequest(object sender, EventArgs e)
    {
        string Authority = Request.Url.GetLeftPart(UriPartial.Authority);   // gets the protocol + domain
        string AbsolutePath = Request.Url.AbsolutePath;                     // gets the requested path
        string InsertedPath = string.Empty;                                 // if QS info exists, we'll add this to the URL
        // if 't' exists as a QS key get its value and contruct new path to insert
        if (Request.QueryString["t"] != null && !string.IsNullOrEmpty(Request.QueryString["t"].ToString()))
            InsertedPath = "/t/" + Request.QueryString["t"].ToString();
        string NewUrl = Authority + InsertedPath + AbsolutePath;
        HttpContext.Current.RewritePath(NewUrl);
    }

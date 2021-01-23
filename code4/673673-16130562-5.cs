    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.AbsolutePath;
        if (string.IsNullOrEmpty(url) ||
            System.IO.Directory.Exists(Server.MapPath(url)))
            return;
        if (url.EndsWith("/"))
        {
            Response.Clear();
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", url.Substring(0, url.Length - 1));
            Response.End();
        }
    }

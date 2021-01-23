    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.AbsolutePath;
        if (string.IsNullOrEmpty(url) ||
            System.IO.Directory.Exists(Server.MapPath(url)))
            return;
        int urlI = url.Length - 1;
        if (url[urlI] == char.Parse("/"))
        {
            Response.Clear();
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", url.Substring(0, urlI));
            Response.End();
        }
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Url.AbsolutePath == "page_expired.aspx")
        {
            return;
        }
        var cache = HttpContext.Current.Cache["ExpireCache"];
        if (cache.ContainsKey(HttpContext.Current.Request.RawUrl) &&
            cache[HttpContext.Current.Request.Url.AbsolutePath] < DateTime.Now)
        {
            HttpContext.Response.Current.Redirect("page_expired.aspx");
        }
    }

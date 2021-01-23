    protected override void OnPreInit(EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("traceid"))
                HttpContext.Current.Response.CacheControl = "no-cache";
            base.OnPreInit(e);
    
        }

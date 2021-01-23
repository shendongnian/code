    private static string ServerPath { get; set; }
    protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            ServerPath = BaseSiteUrl;
        }
        protected static string BaseSiteUrl
        {
            get
            {
                var context = HttpContext.Current;
                if (context.Request.ApplicationPath != null)
                {
                    var baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
                    return baseUrl;
                }
                return string.Empty;
            }
        }

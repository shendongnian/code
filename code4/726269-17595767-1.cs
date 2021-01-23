    public class autocomp : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            OutputCachedPage page = new OutputCachedPage(new OutputCacheParameters
            {
                Duration = 120,
                Location = OutputCacheLocation.Server,
                VaryByParam = "name_startsWith"
            });
            page.ProcessRequest(HttpContext.Current);
            context.Response.ContentType = "application/json";
            context.Response.BufferOutput = true;
            var searchTerm = (context.Request.QueryString["name_startsWith"] + "").Trim();
            context.Response.Write(searchTerm);
            context.Response.Write(DateTime.Now.ToString("s"));
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private sealed class OutputCachedPage : Page
        {
            private OutputCacheParameters _cacheSettings;
    
            public OutputCachedPage(OutputCacheParameters cacheSettings)
            {
                // Tracing requires Page IDs to be unique.
                ID = Guid.NewGuid().ToString();
                _cacheSettings = cacheSettings;
            }
 
            protected override void FrameworkInitialize()
            {
                base.FrameworkInitialize();
                InitOutputCache(_cacheSettings);
            }
        }
    }

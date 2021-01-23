    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //BundleMobileConfig.RegisterBundles(BundleTable.Bundles);
        }
        private bool _isBootStrapped;
        private bool _isBootStrappedAuthenticated;
        public override void Init()
        {
            base.Init();
            // handlers managed by ASP.Net during Forms authentication
            BeginRequest += new EventHandler(BeginRequestHandler);
            PostAuthorizeRequest += new EventHandler(PostAuthHandler);
            EndRequest += new EventHandler(EndRequestHandler);
        }
        public void EndRequestHandler(object sender, EventArgs e)
        {
        }
        public void BeginRequestHandler(object sender, EventArgs e)
        {
            BootStrapUnauthentiated();
        }
        public void PostAuthHandler(object sender, EventArgs e)
        {
            if (_isBootStrappedAuthenticated)
            {
                return; // nuff done...
            }
            BootStrapAuthenticated();
            BootStrapUnauthentiated();
        }
        private void BootStrapAuthenticated()
        {
            if (Request.IsAuthenticated)
            {
                BootStrapHttp(Context);
                BootStrapper.RegisterInfrastureAdapters();
                _isBootStrapped = true;
                _isBootStrappedAuthenticated = true;
            }
        }
        private void BootStrapUnauthentiated()
        {
            if (!_isBootStrapped)
            { // minimal bootstrap for launch but user not yet known, eg logon screen
                BootStrapHttp(Context);
                BootStrapper.RegisterInfrastureAdapters();
               _isBootStrapped = true; // just a connection, if no persisted cookie, the may not be authenticated yet
            }
        }
    }

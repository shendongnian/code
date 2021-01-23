     public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Database.SetInitializer<GratifyGamingContext>(new DatabaseInitializer()); 
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            WebSecurity.InitializeDatabaseConnection(
                      connectionStringName: "DefaultConnection",
                      userTableName: "UserProfile",
                      userIdColumn: "UserID",
                      userNameColumn: "UserName",
                      autoCreateTables: true);
        }
    }

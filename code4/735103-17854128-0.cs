    protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, MigrationConfiguration>());
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }
        public class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                using (var context = new Db())
                    context.Users.Find(1);
                if (!WebSecurity.Initialized)
                    WebSecurity.InitializeDatabaseConnection("Db", "Users", "Id", "UserName",
                                                             autoCreateTables: true);
            }
        }

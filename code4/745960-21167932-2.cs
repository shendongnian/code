    namespace MyProject.MVC.Filters
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
        {
            private static SimpleMembershipInitializer _initializer;
            private static object _initializerLock = new object();
            private static bool _isInitialized;
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Ensure ASP.NET Simple Membership is initialized only once per app start
                LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            }
    
            private class SimpleMembershipInitializer
            {
                public SimpleMembershipInitializer()
                {
                    try
                    {
                        Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, MyProject.Model.Migrations.Configuration>());
    
                        using (var context = new MyContext())
                        {
                            context.Database.Initialize(force: true);
                            if (!context.Database.Exists())
                            {
                                // Create the SimpleMembership database without Entity Framework migration schema
                                ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                            }
                        }
    
                        WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                    }
                }
            }
        }
    }

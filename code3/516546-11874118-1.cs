    public class PerWebRequestLifestyleModule : IHttpModule
    {
        private const string key = "castle.per-web-request-lifestyle-cache";
        private static bool allowDefaultScopeOutOfHttpContext = true;
        private static bool initialized;
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            initialized = true;
            context.EndRequest += Application_EndRequest;
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var scope = GetScope(application.Context, createIfNotPresent: false);
            if (scope != null)
            {
                scope.Dispose();
            }
        }
        private static bool IsRequestAvailable()
        {
            if (HttpContext.Current == null)
            {
                return false;
            }
            try
            {
                if (HttpContext.Current.Request == null)
                {
                    return false;
                }
                return true;
            }
            catch (HttpException)
            {
                return false;
            }
        }
        internal static ILifetimeScope GetScope()
        {
            var context = HttpContext.Current;
            if (initialized)
            {
                return GetScope(context, createIfNotPresent: true);
            }
            else if (allowDefaultScopeOutOfHttpContext && !IsRequestAvailable())
            {
                // We're not running within a Http Request.  If the option has been set to allow a normal scope to 
                // be used in this situation, we'll use that instead
                ILifetimeScope scope = CallContextLifetimeScope.ObtainCurrentScope();
                if (scope == null)
                {
                    throw new InvalidOperationException("Not running within a Http Request, and no Scope was manually created.  Either run from within a request, or call container.BeginScope()");
                }
                return scope;
            }
            else if (context == null)
            {
                throw new InvalidOperationException(
                        "HttpContext.Current is null. PerWebRequestLifestyle can only be used in ASP.Net");
            }
            else
            {
                EnsureInitialized();
                return GetScope(context, createIfNotPresent: true);
            }
        }
        /// <summary>
        ///   Returns current request's scope and detaches it from the request context.
        ///   Does not throw if scope or context not present. To be used for disposing of the context.
        /// </summary>
        /// <returns></returns>
        internal static ILifetimeScope YieldScope()
        {
            var context = HttpContext.Current;
            if (context == null)
            {
                return null;
            }
            var scope = GetScope(context, createIfNotPresent: true);
            if (scope != null)
            {
                context.Items.Remove(key);
            }
            return scope;
        }
        private static void EnsureInitialized()
        {
            if (initialized)
            {
                return;
            }
            var message = new StringBuilder();
            message.AppendLine("Looks like you forgot to register the http module " + typeof(PerWebRequestLifestyleModule).FullName);
            message.AppendLine("To fix this add");
            message.AppendLine("<add name=\"PerRequestLifestyle\" type=\"Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.Windsor\" />");
            message.AppendLine("to the <httpModules> section on your web.config.");
            if (HttpRuntime.UsingIntegratedPipeline)
            {
                message.AppendLine(
                    "Windsor also detected you're running IIS in Integrated Pipeline mode. This means that you also need to add the module to the <modules> section under <system.webServer>.");
            }
            else
            {
                message.AppendLine(
                    "If you plan running on IIS in Integrated Pipeline mode, you also need to add the module to the <modules> section under <system.webServer>.");
            }
    #if !DOTNET35
            message.AppendLine("Alternatively make sure you have " + PerWebRequestLifestyleModuleRegistration.MicrosoftWebInfrastructureDll +
                               " assembly in your GAC (it is installed by ASP.NET MVC3 or WebMatrix) and Windsor will be able to register the module automatically without having to add anything to the config file.");
    #endif
            throw new ComponentResolutionException(message.ToString());
        }
        private static ILifetimeScope GetScope(HttpContext context, bool createIfNotPresent)
        {
            var candidates = (ILifetimeScope)context.Items[key];
            if (candidates == null && createIfNotPresent)
            {
                candidates = new DefaultLifetimeScope(new ScopeCache());
                context.Items[key] = candidates;
            }
            return candidates;
        }
    }

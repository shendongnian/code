    public static class TemplateManager
    {
        static IRazorEngineService Service { get; set; }
        static TemplateServiceConfiguration Configuration { get; set; }
		
        static TemplateManager()
        {
            Configuration = new TemplateServiceConfiguration()
            {
				// setting up our custom template manager so we map files on demand
                TemplateManager = new MyTemplateManager()
            };
            Service = RazorEngineService.Create(Configuration);
            Engine.Razor = Service;
        }
        /// <summary>
        /// Resets the cache.
        /// </summary>
        public static void ResetCache()
        {
            Configuration.CachingProvider = new RazorEngine.Templating.DefaultCachingProvider();
        }
        /// <summary>
        /// Compiles, caches and parses a template using RazorEngine.
        /// </summary>
        /// <param name="templateType">Type of the template.</param>
        /// <param name="anonymousType">Type of the anonymous object.</param>
        /// <param name="cachedEnabled">true to enabled caching; false otherwise</param>
        /// <returns></returns>
        public static string GetTemplate<T>(EmailTemplateType templateType, T anonymousType, bool cachedEnabled = true)
        {
            string templateName = templateType.ToString();
            if (cachedEnabled == false)
                ResetCache();
			// pre-compile, cache & parse the template
			return Engine.Razor.RunCompile(templateName, null, anonymousType);
        }
    }
    public enum EmailTemplateType
    {
        ForgotPassword,
        EmailVerification
    }
	
    public class MyTemplateManager : ITemplateManager
    {
        public ITemplateSource Resolve(ITemplateKey key)
        {
            string file = HttpContext.Current.Server.MapPath(string.Format("~/EmailTemplates/{0}.cshtml", key.Name));
            return new LoadedTemplateSource(System.IO.File.ReadAllText(file), file);
        }
        public ITemplateKey GetKey(string name, ResolveType resolveType, ITemplateKey context)
        {
            return new NameOnlyTemplateKey(name, resolveType, context);
        }
        public void AddDynamic(ITemplateKey key, ITemplateSource source)
        {
            throw new NotImplementedException("dynamic templates are not supported!");
        }
    }
	

    public class HelpController : Controller
        {
            private const string ErrorViewName = "Error";
    
             [InjectionConstructor]
            public HelpController()
                : this(GlobalConfiguration.Configuration)
            {
            }
    
            public HelpController(HttpConfiguration config)
            {
                Configuration = config;
            }
    
            /// <summary>
            /// GlobalConfiguration By default
            /// </summary>
            protected static HttpConfiguration Configuration { get; private set; }
    ....

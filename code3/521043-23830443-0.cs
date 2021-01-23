        public class HelpController : Controller
            {
                private const string ErrorViewName = "Error";
        
        //        public HelpController()
        //            : this(GlobalConfiguration.Configuration)
        //        {
        //        }
        
        //        public HelpController(HttpConfiguration config)
        //        {
        //            Configuration = config;
        //        }
        
                /// <summary>
                /// GlobalConfiguration By default
                /// </summary>
                protected static HttpConfiguration Configuration
                {
                    get { return GlobalConfiguration.Configuration; }
                }
        
                public ActionResult Index()
                {
                    ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
                    return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
                }
    ....

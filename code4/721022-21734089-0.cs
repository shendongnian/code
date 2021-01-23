     public static class DependencyInjection
        {
            public static void Init()
            {
                // Create the container builder.
                var builder = new ContainerBuilder();
                //Register controllers
                builder.RegisterControllers(Assembly.GetExecutingAssembly());
                // Register other dependencies.
                builder.RegisterType<SessionStateProvider>().As<IStateProvider>().InstancePerHttpRequest();
                // Build the container.
                var container = builder.Build();
            
                //Configure ASP.NET MVC the dependency resolver
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }
     public class SessionStateProvider:IStateProvider
    {
        public object this[string key]
        {
            get
            {
                return HttpContext.Current.Session[key];
            }
            set
            {
                HttpContext.Current.Session[key] = value;
            }
        }
        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
    public interface IStateProvider
    {
      object this[string key] { get; set; }
      void Remove(string key);
    }
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyInjection.Init();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
    public abstract class BaseController : Controller
    {
        protected IStateProvider SessionStateProvider { get; private set; }
        public BaseController()
        {
            SessionStateProvider = DependencyResolver.Current.GetService<IStateProvider>();
        }
    }
    public class HomeController : BaseController
    {
     
        public ActionResult Index()
        {
            SessionStateProvider["1"] = 2;
            return View();
        }
    }

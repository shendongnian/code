    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new SessionValidationAttribute());
            // register routes
        }
    }

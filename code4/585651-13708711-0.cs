        public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            HttpContext.Current.Application["PerfilLevel"] = "0";
            AreaRegistration.RegisterAllAreas();

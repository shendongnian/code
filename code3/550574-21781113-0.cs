    // System.Web.WebPages.dll
    using System.Web.Helpers;
    // not a production solution
    public class MvcApplication : HttpApplication {
      protected void Application_Start() {
        AntiForgeryConfig.SuppressIdentityHeuristicCheck = true;
      }
    }

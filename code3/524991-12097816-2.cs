    public class Global : System.Web.HttpApplication
    {
 
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
         
        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("Products", "Products/{Name}", "~/Products.aspx");
        }
 
    }

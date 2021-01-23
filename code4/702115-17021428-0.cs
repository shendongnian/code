    public class MainClassName
     {
       public static void SubClassName(RouteCollection routes)
           {
            routes.MapPageRoute(
             "RouteName",      // Route name
             "{name}-{some extentions}.aspx",      // Route URL (subdomain-example.aspx)
             "~/home.aspx",// Web page to handle route
            );
           }
      }

	public class RouteProvider : IRouteProvider {
        public void RegisterRoutes(RouteCollection routes) {
            //Insert our CustomViewEngine into the top of the System.Web.Mvc.ViewEngines.Engines Collection to be given a higher precedence
            System.Web.Mvc.ViewEngines.Engines.Insert(0, new CustomViewEngine());
        }
        public int Priority {
            get {
                return 1;
            }
        }
    }

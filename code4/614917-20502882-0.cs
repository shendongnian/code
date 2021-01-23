    public class UrlGenerator
    {
        protected string Protocol;
        protected string HostName;
        protected RequestContext RequestContext;
        public RouteCollection RouteCollection;
        public UrlGenerator(string protocol, string hostName, Action<RouteCollection> registerRoutes)
        {
            Protocol = protocol;
            HostName = hostName;
            RouteCollection = new RouteCollection();
            registerRoutes(RouteCollection);
            // Construct a request context with as little as possible
            RequestContext = new RequestContext(new HttpContextWrapper(new HttpContext(new HttpRequest(null, "http://x.com", null), new HttpResponse(null))), new RouteData());
        }
        public string GetUrl(string action, string controller, object routeData)
        {
            return GetUrl(action, controller, new RouteValueDictionary(routeData));
        }
        public string GetUrl(string action, string controller, RouteValueDictionary routeData)
        {
            return UrlHelper.GenerateUrl(null, action, controller, Protocol, HostName, null, routeData, RouteCollection, RequestContext, false);
        }
    }

        public abstract class BaseRouteResolver : IRouteResolver
    {
        protected HttpContext _context;
        protected RouteCollection _routeCollection;
        public BaseRouteResolver()
            :this(RouteTable.Routes, HttpContext.Current)
        {
        }
        public BaseRouteResolver(RouteCollection routeCollection, HttpContext context)
        {
            _routeCollection = routeCollection;
            _context = context;
        }
        public string GetRouteUrl(object routeParameters)
        {
            return GetRouteUrl(new RouteValueDictionary(routeParameters));
        }
        public string GetRouteUrl(System.Web.Routing.RouteValueDictionary routeParameters)
        {
            return GetRouteUrl(null, new RouteValueDictionary(routeParameters));
        }
        public string GetRouteUrl(string routeName, object routeParameters)
        {
            return GetRouteUrl(routeName, new RouteValueDictionary(routeParameters));
        }
        public string GetRouteUrl(string routeName, System.Web.Routing.RouteValueDictionary routeParameters)
        {
            VirtualPathData virtualPath = _routeCollection.GetVirtualPath(_context.Request.RequestContext, routeName, routeParameters);
            if (virtualPath != null)
                return virtualPath.VirtualPath;
            return null;
        }
        public abstract string GetUrlFor(Product product);
        public abstract string GetUrlFor(Category category);
        public abstract string GetUrlFor(Brand brand);
    }

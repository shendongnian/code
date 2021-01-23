    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    namespace yourbelovedNamespace
    {
        /// <summary>
        /// Provides properties and methods for defining a seo friendly route
        /// </summary>
        public class SeoFriendlyRoute : Route
        {
            #region Constructors
    
            public SeoFriendlyRoute(string url, IRouteHandler routeHandler)
                : base(url, routeHandler)
            {
            }
    
            public SeoFriendlyRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
                : base(url, defaults, routeHandler)
            {
            }
    
            public SeoFriendlyRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints,
                                    IRouteHandler routeHandler)
                : base(url, defaults, constraints, routeHandler)
            {
            }
    
            public SeoFriendlyRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints,
                                    RouteValueDictionary dataTokens, IRouteHandler routeHandler)
                : base(url, defaults, constraints, dataTokens, routeHandler)
            {
            }
    
            #endregion
    
            public override RouteData GetRouteData(HttpContextBase httpContext)
            {
                RouteData data = base.GetRouteData(httpContext);
                return data;
            }
    
            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
            {
                var trimmedValues = new RouteValueDictionary();
                foreach (var value in values)
                {
                    if (value.Value != null && value.Key != "controller" && value.Key != "action")
                        trimmedValues.Add(value.Key, GenerateSeourl(value.Value.ToString()));
                    else
                    {
                        trimmedValues.Add(value.Key, value.Value != null ? value.Value.ToString() : value.Value);
                    }
    
                }
                VirtualPathData data = base.GetVirtualPath(requestContext, trimmedValues);
                if (data != null)
                    data.VirtualPath = data.VirtualPath;
                return data;
            }
    
            private static string GenerateSeourl(string url)
            {
                // make the url lowercase
                var encodedUrl = (url ?? "");
                encodedUrl = encodedUrl
                    .Replace("%20", "")
                    .Replace(" ", "")
                    .Replace("/", "-");
                return encodedUrl;
            }
        }
    
        public static class SeoFriendlyRouteCollectionExtensions
        {
            //Override for localized route
            public static Route MapSeoFriendlyRoute(this RouteCollection routes, string name, string url, object defaults)
            {
                return routes.MapSeoFriendlyRoute(name, url, defaults, null, null);
            }
    
            public static Route MapSeoFriendlyRoute(this RouteCollection routes, string name, string url, object defaults,
                                                    object constraints)
            {
                return routes.MapSeoFriendlyRoute(name, url, defaults, constraints, null);
            }
    
            public static Route MapSeoFriendlyRoute(this RouteCollection routes, string name, string url, object defaults,
                                                    object constraints, string[] namespaces)
            {
                if (routes == null)
                {
                    throw new ArgumentNullException("routes");
                }
                if (url == null)
                {
                    throw new ArgumentNullException("url");
                }
                var item = new SeoFriendlyRoute(url, new MvcRouteHandler())
                               {
                                   Defaults = new RouteValueDictionary(defaults),
                                   Constraints = new RouteValueDictionary(constraints),
                                   DataTokens = new RouteValueDictionary()
                               };
                if ((namespaces != null) && (namespaces.Length > 0))
                {
                    item.DataTokens["Namespaces"] = namespaces;
                }
                routes.Add(name, item);
                return item;
                //return routes.MapSeoFriendlyRoute(name, urlPattern, defaults, null);
            }
    
            private static Route MapSeoFriendlyRoute(this AreaRegistrationContext context, string name, string url,
                                                     object defaults, object constraints, string[] namespaces)
            {
                if ((namespaces == null) && (context.Namespaces != null))
                {
                    namespaces = context.Namespaces.ToArray();
                }
    
                Route route = context.Routes.MapSeoFriendlyRoute(name, url, defaults, constraints, namespaces);
                route.DataTokens["area"] = context.AreaName;
                bool flag = (namespaces == null) || (namespaces.Length == 0);
                route.DataTokens["UseNamespaceFallback"] = flag;
                return route;
            }
    
            public static Route MapSeoFriendlyRoute(this AreaRegistrationContext context, string name, string url,
                                                    object defaults, string[] namespaces)
            {
                return context.MapSeoFriendlyRoute(name, url, defaults, null, namespaces);
            }
    
            public static Route MapSeoFriendlyRoute(this AreaRegistrationContext context, string name, string url,
                                                    object defaults, object constraints)
            {
                return context.MapSeoFriendlyRoute(name, url, defaults, constraints, null);
            }
    
            public static Route MapSeoFriendlyRoute(this AreaRegistrationContext context, string name, string url,
                                                    string[] namespaces)
            {
                return context.MapSeoFriendlyRoute(name, url, null, namespaces);
            }
    
            public static Route MapSeoFriendlyRoute(this AreaRegistrationContext context, string name, string url,
                                                    object defaults)
            {
                return context.MapSeoFriendlyRoute(name, url, defaults, null);
            }
    
            public static Route MapSeoFriendlyRoute(this AreaRegistrationContext context, string name, string url)
            {
                return context.MapSeoFriendlyRoute(name, url, null);
            }
        }
    }

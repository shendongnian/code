    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    namespace InfosoftConnectSandbox
    {
        public class RouteConfig
        {
            class TestRoute : RouteBase
            {
                Regex re = new Regex(@"folder/city-(?<pid>\d)-(?<id>\d)-.*");
    
                public override RouteData GetRouteData(HttpContextBase httpContext)
                {
                    var data = new RouteData();
    
                    var url = httpContext.Request.Url.ToString();
    
                    if (!re.IsMatch(url))
                    {
                        return null;
                    }
    
                    foreach (Match m in re.Matches(url))
                    {
                        data.Values["pid"] = m.Groups["pid"].Value;
                        data.Values["id"] = m.Groups["id"].Value;
                    }
    
                    data.RouteHandler = new PageRouteHandler("~/mypage.aspx");
    
                    return data;
                }
    
                public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
                {
                    return new VirtualPathData(this, "~/mypage.aspx");
                }
            }
    
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                routes.Add(new TestRoute());
    
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            }
        }
    }

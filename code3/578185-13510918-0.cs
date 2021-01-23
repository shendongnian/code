    using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	namespace Tipser.Web
	{
	    public class MyMvcApplication : HttpApplication
	    {
	        public static void RegisterRoutes(RouteCollection routes)
	        {
	            routes.MapRoute(
	                "ArticleRoute",
	                "{articleName}",
	                new { Controller = "Home", Action = "Index", articleName = UrlParameter.Optional },
	                new { userFriendlyURL = new ArticleConstraint() }
	                );
	        }
	        public class ArticleConstraint : IRouteConstraint
	        {
	            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
	            {
	                var articleName = values["articleName"] as string;
	                //determine if there is a valid article
	                if (there_is_there_any_article_matching(articleName))
	                    return true;
	                return false;
	            }
	        }
	    }
	}

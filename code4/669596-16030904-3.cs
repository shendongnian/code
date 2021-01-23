    public class CmsUrlConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var db = new MvcCMS.Models.MvcCMSContext();
            return db.CMSPages.Any(p => p.Permalink == values[parameterName].ToString());
        }
    }

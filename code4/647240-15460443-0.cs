    public class MyRoute : Route
    {
        public MyRoute(string url, object defaults): base(url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        { 
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (values["action"] != null)
                values["action"] = values["action"].ToString().ToLowerInvariant();
            if (values["controller"] != null)
                values["controller"] = values["controller"].ToString().ToLowerInvariant();
            return base.GetVirtualPath(requestContext, values);
        }
    }
    routes.Add("Default",new MyRoute("{controller}/{action}/{id}",
                    new { controller = "Home", action = "Index", id = MyUrlParameter.Optional }));

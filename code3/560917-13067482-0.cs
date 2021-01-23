    public class LangRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (requestContext.RouteData.Values.ContainsKey("lang"))
            {
                var culture = new CultureInfo(requestContext.RouteData.Values["lang"].ToString());
                if (culture != null)
                {
                    Thread.CurrentThread.CurrentUICulture = culture;
                    Thread.CurrentThread.CurrentCulture = culture;
                }
            }
            return base.GetHttpHandler(requestContext);
        }
    }

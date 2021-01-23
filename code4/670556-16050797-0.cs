    public class ParameterizedRoute : RouteBase
    {
        const Dictionary<string,int> CustomParameters = new Dictionary<string,int> {{"1",16},{"2",1},{"3",20} };
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = new RouteData(this, new MvcRouteHandler());
            routeData.Values.Add("controller", "Datasheet");
            routeData.Values.Add("action", datasheetUrl.Action);
            var pageId = httpContext.Request.QueryString["PageId"].ToString();
            var param = CustomParameters[pageId];
            routeData.Values.Add("PageId", pageId);
            routeData.Values.Add("Parameter", param);
            return routeData;
        }
    }

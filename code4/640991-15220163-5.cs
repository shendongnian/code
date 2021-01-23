    var separator = "bali";
    routes.Add("villadetail",
                new CustomRoute("{sublocationurl}-"+separator+"-{villaurl}-details",
                new RouteValueDictionary(),
                new RouteValueDictionary{{ "sublocationurl", @".+"}},
                new RouteValueDictionary()
                , separator, new System.Web.Routing.PageRouteHandler("~/VillaDetail.aspx",false)));

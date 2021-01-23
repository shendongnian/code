    using System.Web.Routing;
    using MvcCodeRouting;
    void RegisterRoutes(RouteCollection routes) {
        routes.MapCodeRoutes(typeof(Controllers.HomeController));
    }

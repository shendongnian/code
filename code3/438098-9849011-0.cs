    using System.Web.Http;
    ...
    public override void RegisterArea(AreaRegistrationContext context)
    {
            context.Routes.MapHttpRoute(
                name: this.AreaName,
                routeTemplate: this.AreaName + "/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "GetVoucherTypesForPartner",
                routeTemplate: "api/Partner/{partnerId}/VoucherType",
                defaults: new { controller = "Partner", action = "GetVoucherTypesForPartner" }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

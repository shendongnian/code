    using System.Web.Http;
    namespace MarwakoService
    {
          public static class WebApiConfig
          {
                public static void Register(HttpConfiguration config)
                {
                    // Web API routes
                    config.MapHttpAttributeRoutes();
                   // Other Web API configuration not shown.
                }
           }
     }

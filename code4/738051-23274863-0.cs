    public static class BreezeWebApiConfig {
    
        public static void RegisterBreezePreStart() {
          GlobalConfiguration.Configuration.Routes.MapHttpRoute(
              name: "BreezeApi",
              routeTemplate: "api/{controller}/{action}"
          );
        }
      }
    }

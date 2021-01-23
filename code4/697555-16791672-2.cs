    [assembly: System.Web.PreApplicationStartMethod(typeof(PreApplicationConfiguration), "Configure")]
    namespace MyExtrarnalLibrary
    {
        public   class PreApplicationConfiguration  {
         
            public static void Configure()
            { 
                //to register handler - handler must implement IRouteHandler
                RouteTable.Routes.Add(new Route("myspecialurl.asmx",new MyHttpHandler()));
                // if you want to register httpmodule , you can do this.
                Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(MyHttpModule));    
            }
         
        } 
    }

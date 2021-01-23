    private IDisposable _webApp = null;
    public override bool OnStart() {
       ServicePointManager.DefaultConnectionLimit = 5;
       
       var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["DefaultEndpoint"];
       var baseUri = string.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);
       
       _webApp = WebApp.Start<Startup>(new StartOptions(baseUri));
       
       return base.OnStart();
    }
    public override void OnStop() {
        if (_webApp != null) {
            _webApp.Dispose();
        }
        base.OnStop();
    }
    ...
    
    using System.Web.Http;
    using Owin;
    
    class Startup {
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();
            
            config.Routes.MapHttpRoutes("Default", "{controller}/{id}",
                                        new { id = RouteParameter.Optional });
            app.UseWebApi(config);
                           
        }
    }

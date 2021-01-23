    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Reflection;
    using System.IO;
    
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.SelfHost;
    
    namespace WebAPISelfHost
    {
        public partial class Service1 : ServiceBase
        {
            static HttpSelfHostServer CreateHost(string address)
            {
                // Create normal config
                HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(address);
    
                // Set our own assembly resolver where we add the assemblies we need
                AssembliesResolver assemblyResolver = new AssembliesResolver();
                config.Services.Replace(typeof(IAssembliesResolver), assemblyResolver);
    
                // Add a route
                config.Routes.MapHttpRoute(
                  name: "default",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { controller = "Home", id = RouteParameter.Optional });
    
                HttpSelfHostServer server = new HttpSelfHostServer(config);
                server.OpenAsync().Wait();
    
                return server;
            }
    
            public Service1()
            {
                InitializeComponent();
    
            }
    
            protected override void OnStart(string[] args)
            {
                HttpSelfHostServer server = CreateHost("http://localhost:8080");
            }
    
            protected override void OnStop()
            {
            }
        }
    
        class AssembliesResolver : DefaultAssembliesResolver
        {
            public override ICollection<Assembly> GetAssemblies()
            {
                ICollection<Assembly> baseAssemblies = base.GetAssemblies();
                List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
    
                assemblies.Add(Assembly.LoadFrom(@"C:\Users\david.kolosowski\Documents\Visual Studio 2010\Projects\WebAPISelfHost\WebAPISelfHost\bin\Debug\ClassLibrary1.dll"));
    
                return assemblies;
            }
        }
    }

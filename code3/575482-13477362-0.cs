    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Hosting.Self;
    
    namespace Server1
    {
        public class Server : NancyModule
        {
            private static NancyHost _server;
    
            public static void Start()
            {
                _server = new NancyHost(new Bootstrapper(), new Uri("http://localhost:8686"));
                _server.Start();
            }
    
            public Server()
            {
                Get["/"] = _ => "this is server 1";
            }
        }
    
        public class Bootstrapper : DefaultNancyBootstrapper
        {
            /// <summary>
            /// Register only NancyModules found in this assembly
            /// </summary>
            protected override IEnumerable<ModuleRegistration> Modules
            {
                get
                {
                    return GetType().Assembly.GetTypes().Where(type => type.BaseType == typeof(NancyModule)).Select(type => new ModuleRegistration(type, this.GetModuleKeyGenerator().GetKeyForModuleType(type)));
                }
            }
        }
    }

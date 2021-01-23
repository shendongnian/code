    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Castle.Facilities.WcfIntegration;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    namespace SelfHost
    {
        [ServiceContract(SessionMode = SessionMode.Required)]
        public interface IHelloWorldService
        {
            [OperationContract]
            string SayHello(string name);
        }
        [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerSession)]
        public class HelloWorldService : IHelloWorldService
        {
            private readonly PerSession _perSession;
            public HelloWorldService(PerSession perSession)
            {
                _perSession = perSession;
            }
            public string SayHello(string name)
            {
                return string.Format("Hello, {0} {1}", name, _perSession.Info());
            }
        }
            public class PerSession
            {
                private readonly string _now;
                public PerSession()
                {
                    _now = DateTime.Now.ToString();
                }
                public string Info()
                {
                    return _now;
                }
            }
        internal class Program
        {
            private static void Main(string[] args)
            {
                Uri baseAddress = new Uri("http://localhost:8080/hello");
                var container = new WindsorContainer();
                container.AddFacility<WcfFacility>();
                container.Register(
                    Component.For<PerSession>().LifeStyle.PerWebRequest,
                    Component.For<IHelloWorldService>()
                        .ImplementedBy<HelloWorldService>()
                        .LifeStyle.PerWebRequest
                        .AsWcfService(
                            new DefaultServiceModel()
                                .AddBaseAddresses(baseAddress)
                                .AddEndpoints(WcfEndpoint.BoundTo(new WSHttpBinding()).At("myBinding"))
                                .PublishMetadata(o => o.EnableHttpGet())
                        )
                    );
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
            }
        }
    }

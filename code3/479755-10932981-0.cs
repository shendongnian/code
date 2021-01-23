    public class StackOverflow_10932251
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string Echo(string text);
        }
        public class Service : ITest
        {
            public string MyProperty { get; set; }
            public string Echo(string text)
            {
                Console.WriteLine("Inside Service.Echo, MyProperty = {0}", this.MyProperty);
                return text;
            }
        }
        static Binding GetBinding()
        {
            var result = new WSHttpBinding(SecurityMode.None);
            return result;
        }
        public class MyInstanceProvider : IEndpointBehavior, IInstanceProvider
        {
            string propertyValue;
            public MyInstanceProvider(string propertyValue)
            {
                this.propertyValue = propertyValue;
            }
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.InstanceProvider = this;
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
            public object GetInstance(InstanceContext instanceContext, Message message)
            {
                return new Service { MyProperty = this.propertyValue };
            }
            public object GetInstance(InstanceContext instanceContext)
            {
                return new Service { MyProperty = this.propertyValue };
            }
            public void ReleaseInstance(InstanceContext instanceContext, object instance)
            {
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), GetBinding(), "");
            endpoint.Behaviors.Add(new MyInstanceProvider("asd"));
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(GetBinding(), new EndpointAddress(baseAddress));
            ITest proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Echo("Hello"));
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

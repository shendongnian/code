    public class StackOverflow_8854137
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string Echo(string text);
        }
        public class Service : ITest
        {
            public string Echo(string text)
            {
                return text;
            }
        }
        class MyBehavior : IEndpointBehavior, IDispatchMessageInspector
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                try
                {
                    Guid tokenId = request.Headers.GetHeader<Guid>("Token", "System");
                    Console.WriteLine("Token: {0}", tokenId);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}: {1}", e.GetType().FullName, e.Message);
                }
                return null;
            }
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "");
            endpoint.Behaviors.Add(new MyBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            ITest proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Echo("No token"));
            using (new OperationContextScope((IContextChannel)proxy))
            {
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("Token", "System", Guid.NewGuid()));
                Console.WriteLine(proxy.Echo("With token"));
            }
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

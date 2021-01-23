    public class StackOverflow_10721469
    {
        public class ESBAPICreationAttribute : Attribute, IContractBehavior
        {
            public void AddBindingParameters(
                ContractDescription contractDescription,
                ServiceEndpoint endpoint,
                BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(
                ContractDescription contractDescription,
                ServiceEndpoint endpoint,
                ClientRuntime clientRuntime)
            {
            }
            public void ApplyDispatchBehavior(
                ContractDescription contractDescription,
                ServiceEndpoint endpoint,
                DispatchRuntime dispatchRuntime)
            {
                dispatchRuntime.InstanceContextInitializers.Add(new PSESBAPIInitializer());
                Logger.Log("Instance context initializer added");
            }
            public void Validate(
                ContractDescription contractDescription,
                ServiceEndpoint endpoint)
            {
            }
        }
        public class PSESBAPIInitializer : IInstanceContextInitializer
        {
            private static ESBAPIManager _manager = null;
            public PSESBAPIInitializer()
            {
                if (_manager == null)
                {
                    _manager = new ESBAPIManager();
                    Logger.Log("New instance of API manager initialized");
                }
            }
            public void Initialize(InstanceContext instanceContext, Message message)
            {
                Logger.Log("Extension added to the instance context");
                instanceContext.Extensions.Add(new PSESBAPIExtension(_manager));
            }
        }
        [DataContract]
        public class PSESBAPIExtension : IExtension<InstanceContext>
        {
            private ESBAPIManager _manager;
            [DataMember]
            public ESBAPIManager ESBAPIManager
            {
                get { return _manager; }
            }
            public PSESBAPIExtension(ESBAPIManager Manager)
            {
                Logger.Log("PSESBAPIExtension constructor called");
                _manager = Manager;
            }
            public void Attach(InstanceContext owner)
            {
            }
            public void Detach(InstanceContext owner)
            {
            }
        }
        public class ESBAPIManager { }
        public class PSRestServiceHost : ServiceHost
        {
            public PSRestServiceHost(Type t, Uri[] addresses)
                : base(t, addresses)
            {
                Logger.Log("PSRestServiceHost constructor");
            }
        }
        public class PSRestServiceFactory : ServiceHostFactoryBase
        {
            public override ServiceHostBase CreateServiceHost(string service, Uri[] baseAddresses)
            {
                // The service parameter is ignored here because we know our service. 
                PSRestServiceHost serviceHost = new PSRestServiceHost(typeof(PSRestService), baseAddresses);
                serviceHost.Opening += new EventHandler(serviceHost_Opening);
                serviceHost.Opened += new EventHandler(serviceHost_Opened);
                serviceHost.Closing += new EventHandler(serviceHost_Closing);
                serviceHost.Closed += new EventHandler(serviceHost_Closed);
                serviceHost.Faulted += new EventHandler(serviceHost_Faulted);
                serviceHost.UnknownMessageReceived += new EventHandler<UnknownMessageReceivedEventArgs>(serviceHost_UnknownMessageReceived);
                return serviceHost;
            }
            void serviceHost_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
            {
                Logger.Log("Unknown Message Received");
            }
            void serviceHost_Faulted(object sender, EventArgs e)
            {
                Logger.Log("service faulted");
            }
            void serviceHost_Closed(object sender, EventArgs e)
            {
                Logger.Log("service closed");
            }
            void serviceHost_Closing(object sender, EventArgs e)
            {
                Logger.Log("service closing by sender: {0}", sender.GetType().ToString());
            }
            void serviceHost_Opened(object sender, EventArgs e)
            {
                Logger.Log("service opened by sender: {0}", sender.GetType().ToString());
            }
            void serviceHost_Opening(object sender, EventArgs e)
            {
                Logger.Log("service opening by sender: {0}", sender.GetType().ToString());
            }
        }
        [ServiceContract]
        public interface IPSRestService
        {
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "blockActivityTrans", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
            transAckResponseData PostBlockActivity(blockActivityData blockactivitydata);
        }
        [ESBAPICreation]
        public class PSRestService : IPSRestService
        {
            public transAckResponseData PostBlockActivity(blockActivityData blockactivitydata)
            {
                return new transAckResponseData();
            }
        }
        public class blockActivityData { }
        public class transAckResponseData { }
        public class Logger
        {
            public static void Log(string text, params object[] args)
            {
                if (args != null && args.Length > 0) text = string.Format(text, args);
                Console.WriteLine(text);
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHostFactoryBase factory = new PSRestServiceFactory();
            ServiceHost host = (ServiceHost)factory.CreateServiceHost("unused", new Uri[] { new Uri(baseAddress) });
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            Console.WriteLine(c.UploadString(baseAddress + "/blockActivityTrans", "null"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

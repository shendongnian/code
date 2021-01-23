    [ServiceContract(Namespace = "http://example.com/Command")]
    interface ICommandService {
     
        [OperationContract]
        string SendCommand(string action, string data);
     
    }
    
    class CommandClient {
     
        private static readonly Uri ServiceUri = new Uri("net.pipe://localhost/Pipe");
        private static readonly string PipeName = "Command";
        private static readonly EndpointAddress ServiceAddress = new EndpointAddress(string.Format(CultureInfo.InvariantCulture, "{0}/{1}", ServiceUri.OriginalString, PipeName));
        private static readonly ICommandService ServiceProxy = ChannelFactory<ICommandService>.CreateChannel(new NetNamedPipeBinding(), ServiceAddress);
     
        public static string Send(string action, string data) {
            return ServiceProxy.SendCommand(action, data);
        }
    }
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class CommandService : ICommandService {
        public string SendCommand(string action, string data) {
            //handling incoming requests
        }
    }
    static class CommandServer {
     
        private static readonly Uri ServiceUri = new Uri("net.pipe://localhost/Pipe");
        private static readonly string PipeName = "Command";
     
        private static CommandService _service = new CommandService();
        private static ServiceHost _host = null;
     
        public static void Start() {
            _host = new ServiceHost(_service, ServiceUri);
            _host.AddServiceEndpoint(typeof(ICommandService), new NetNamedPipeBinding(), PipeName);
            _host.Open();
        }
     
        public static void Stop() {
            if ((_host != null) && (_host.State != CommunicationState.Closed)) {
                _host.Close();
                _host = null;
            }
        }
    }

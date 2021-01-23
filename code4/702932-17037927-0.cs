    [ServiceContract]
        public interface IBlissRequest
        {
            [OperationContract]
            object SystemRequest(string InstanceName, string MethodName, params object[] Parameters);
        }
        public class BlissRequest : IBlissRequest
        {
            public object SystemRequest(string InstanceName, string MethodName, params object[] Parameters)
            {
                return System21.BlissProcessingUnit.BPU.RequestFromIBC(InstanceName, MethodName, Parameters);
            }
        }
    public static object InvokeMethod(string targetIpAddress, string InstanceName, string MethodName, params object[] Parameters)
            {
                try
                {
                    var ep = "net.tcp://" + targetIpAddress + ":9985/IBC";
                    NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                    ChannelFactory<IBlissRequest> pipeFactory = new ChannelFactory<IBlissRequest>(binding, new EndpointAddress(ep));
                    IBlissRequest pipeProxy = pipeFactory.CreateChannel();
                    return pipeProxy.SystemRequest(InstanceName, MethodName, Parameters);
                }
                catch 
                {
                    BPUConsole.WriteLine(BPUConsole.WriteSource.IBC, "Unable to execute method: '" + MethodName +"' on Instance: '"+InstanceName+"' becouse IBC is unable to connect to: "+ targetIpAddress);
                    throw new Exception("Unable to connect to: " + targetIpAddress);
                }
            }
            public static void StartIBC()
            {
                var uri = "net.tcp://" + BlissProcessingUnit.BPUInformation.LocalIpAddresses[0] + ":9985";
                Console.WriteLine("Opening connection on: " + uri);
                ServiceHost host = new ServiceHost(typeof(BlissRequest), new Uri[] { new Uri(uri) });
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                host.AddServiceEndpoint(typeof(IBlissRequest), binding, "IBC");
                host.Open();
                Console.WriteLine("Service is available. " + "Press <ENTER> to exit.");
            }

    public class StackOverflow_15637994
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            string Echo(string text);
            [OperationContract]
            int Execute(string op, int x, int y);
            [OperationContract]
            bool InOutAndRefParameters(int x, ref int y, out int z);
        }
        public class Service : ITest
        {
            public string Echo(string text)
            {
                return text;
            }
            public int Execute(string op, int x, int y)
            {
                return x + y;
            }
            public bool InOutAndRefParameters(int x, ref int y, out int z)
            {
                z = y;
                y = x;
                return true;
            }
        }
        public class MyInspector : IParameterInspector
        {
            string[] inputParameterNames;
            string[] outputParameterNames;
            public MyInspector(string[] inputParameterNames, string[] outputParameterNames)
            {
                this.inputParameterNames = inputParameterNames;
                this.outputParameterNames = outputParameterNames;
            }
            public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
            {
                Console.WriteLine("Operation: {0}", operationName);
                Console.WriteLine("  Result: {0}", returnValue);
                for (int i = 0; i < outputs.Length; i++)
                {
                    Console.WriteLine("  [out] {0}: {1}", this.outputParameterNames[i], outputs[i]);
                }
            }
            public object BeforeCall(string operationName, object[] inputs)
            {
                Console.WriteLine("Operation: {0}", operationName);
                for (int i = 0; i < inputs.Length; i++)
                {
                    Console.WriteLine("  {0}: {1}", this.inputParameterNames[i], inputs[i]);
                }
                return null;
            }
        }
        public class MyBehavior : IEndpointBehavior
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                foreach (var operation in endpoint.Contract.Operations)
                {
                    string[] inputParamNames = operation.Messages[0].Body.Parts
                        .OrderBy(mpd => mpd.Index)
                        .Select(mpd => mpd.Name)
                        .ToArray();
                    string[] outputParamNames = null;
                    if (operation.Messages.Count > 1)
                    {
                        outputParamNames = operation.Messages[1].Body.Parts
                            .OrderBy(mpd => mpd.Index)
                            .Select(mpd => mpd.Name)
                            .ToArray();
                    }
                    MyInspector inspector = new MyInspector(inputParamNames, outputParamNames);
                    endpointDispatcher.DispatchRuntime.Operations[operation.Name].ParameterInspectors.Add(inspector);
                }
            }
            public void Validate(ServiceEndpoint endpoint)
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
            proxy.Echo("Hello");
            proxy.Execute("foo", 2, 5);
            int z;
            int y = 2;
            proxy.InOutAndRefParameters(3, ref y, out z);
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

    public class StackOverflow_12089879
    {
        [ServiceContract(SessionMode = SessionMode.Required)]
        public interface IStackCalculator
        {
            [OperationContract]
            void Enter(double value);
            [OperationContract]
            double Add();
            [OperationContract]
            double Subtract();
            [OperationContract]
            double Multiply();
            [OperationContract]
            double Divide();
        }
        public class StackCalculator : IStackCalculator
        {
            public Stack<double> stack = new Stack<double>();
            public void Enter(double value)
            {
                Console.WriteLine("Entering {0}", value);
                stack.Push(value);
            }
            public double Add()
            {
                return Execute("Add", (x, y) => x + y);
            }
            public double Subtract()
            {
                return Execute("Subtract", (x, y) => x - y);
            }
            public double Multiply()
            {
                return Execute("Multiply", (x, y) => x * y);
            }
            public double Divide()
            {
                return Execute("Divide", (x, y) => x / y);
            }
            private double Execute(string operationName, Func<double, double, double> operation)
            {
                double first = stack.Pop();
                double second = stack.Pop();
                double result = operation(first, second);
                Console.WriteLine("Executing {0}({1}, {2}), result = {3}", operationName, first, second, result);
                stack.Push(result);
                return result;
            }
        }
        static Binding GetBinding()
        {
            var result = new NetTcpBinding(SecurityMode.None);
            return result;
        }
        public class MyInstanceContextInitializer : IEndpointBehavior, IInstanceContextInitializer
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.InstanceContextInitializers.Add(this);
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
            public void Initialize(InstanceContext instanceContext, Message message)
            {
                RemoteEndpointMessageProperty remp = (RemoteEndpointMessageProperty)message.Properties[RemoteEndpointMessageProperty.Name];
                Console.WriteLine("Starting new session from {0}:{1}", remp.Address, remp.Port);
                Console.WriteLine("If session should not be started, throw an exception here");
            }
        }
        public static void Test()
        {
            string baseAddress = "net.tcp://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(StackCalculator), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IStackCalculator), GetBinding(), "");
            endpoint.Behaviors.Add(new MyInstanceContextInitializer());
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<IStackCalculator> factory = new ChannelFactory<IStackCalculator>(GetBinding(), new EndpointAddress(baseAddress));
            IStackCalculator proxy = factory.CreateChannel();
            proxy.Enter(40);
            proxy.Enter(30);
            proxy.Enter(20);
            proxy.Add();
            proxy.Subtract();
            ChannelFactory<IStackCalculator> factory2 = new ChannelFactory<IStackCalculator>(GetBinding(), new EndpointAddress(baseAddress));
            IStackCalculator proxy2 = factory.CreateChannel();
            proxy2.Enter(40);
            proxy2.Enter(30);
            proxy2.Enter(20);
            proxy2.Add();
            proxy2.Subtract();
            ((IClientChannel)proxy).Close();
            factory.Close();
            ((IClientChannel)proxy2).Close();
            factory2.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

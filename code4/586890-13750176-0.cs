    public class StackOverflow_13739729
    {
        [ServiceContract(Namespace = "http://something.org")]
        public interface ITest
        {
            [XmlSerializerFormat, OperationContract(Name = "sendCommand")]
            void SendCommand(SendCommandRequest req);
        }
        public class Service : ITest
        {
            public void SendCommand(SendCommandRequest req)
            {
                Console.WriteLine("In service");
            }
        }
        [MessageContract(WrapperName = "SendCommandRequest", WrapperNamespace = "http://something.org")]
        public class SendCommandRequest
        {
            [MessageBodyMember]
            public CMD CMD { get; set; }
        }
        [XmlType]
        public class CMD
        {
            [XmlElement]
            public Station Station { get; set; }
        }
        public class Station
        {
            [XmlAttribute]
            public string Address { get; set; }
            [XmlElement]
            public Platform Platform { get; set; }
        }
        public class Platform
        {
            string[] validCommands = new[] { "-1", "0", "1", "2", "3", "4", "5" };
            string[] command;
            [XmlAttribute]
            public string Address { get; set; }
            [XmlElement]
            public string[] Command
            {
                get { return this.command; }
                set
                {
                    if (value != null)
                    {
                        if (!value.All(c => validCommands.Contains(c)))
                        {
                            throw new ArgumentException("Invalid command");
                        }
                    }
                    this.command = value;
                }
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "");
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            ITest proxy = factory.CreateChannel();
            SendCommandRequest req = new SendCommandRequest
            {
                CMD = new CMD
                {
                    Station = new Station
                    {
                        Address = "ABC",
                        Platform = new Platform
                        {
                            Address = "DEF",
                            Command = new string[] { "5" }
                        }
                    }
                }
            };
            proxy.SendCommand(req);
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

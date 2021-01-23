    public class Post_8b2c7ad7_b1c3_410b_b907_f25cee637110
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public override string ToString()
            {
                return string.Format("Person[Name={0},Age={1}]", Name, Age);
            }
        }
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            object Echo(object obj);
        }
        public class Service : ITest
        {
            public object Echo(object obj)
            {
                return obj;
            }
        }
        public class ReplaceSerializerOperationBehavior : DataContractSerializerOperationBehavior
        {
            public ReplaceSerializerOperationBehavior(OperationDescription operation)
                : base(operation)
            {
            }
            public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
            {
                return new NetDataContractSerializer(name, ns);
            }
            public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
            {
                return new NetDataContractSerializer(name, ns);
            }
            public static void ReplaceSerializer(ServiceEndpoint endpoint)
            {
                foreach (var operation in endpoint.Contract.Operations)
                {
                    for (int i = 0; i < operation.Behaviors.Count; i++)
                    {
                        if (operation.Behaviors[i] is DataContractSerializerOperationBehavior)
                        {
                            operation.Behaviors[i] = new ReplaceSerializerOperationBehavior(operation);
                            break;
                        }
                    }
                }
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            var endpoint = host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "");
            ReplaceSerializerOperationBehavior.ReplaceSerializer(endpoint);
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            ReplaceSerializerOperationBehavior.ReplaceSerializer(factory.Endpoint);
            ITest proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Echo("Hello"));
            Console.WriteLine(proxy.Echo(123.456));
            Console.WriteLine(proxy.Echo(new Uri("http://tempuri.org")));
            Console.WriteLine(proxy.Echo(new Person { Name = "John Doe", Age = 33 }));
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

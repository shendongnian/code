    public class StackOverflow_12733486
    {
        [ServiceContract(Namespace = "")]
        [XmlSerializerFormat]
        public interface ITest
        {
            [OperationContract]
            SavePetsResponse SavePets(SavePetsRequest request);
        }
        public class Service : ITest
        {
            public SavePetsResponse SavePets(SavePetsRequest request)
            {
                return new SavePetsResponse { Result = true };
            }
        }
        [MessageContract(IsWrapped = false)]
        public class SavePetsRequest
        {
            [MessageBodyMember]
            public Pets Pets { get; set; }
        }
        [MessageContract(WrapperNamespace = "")]
        public class SavePetsResponse
        {
            [MessageBodyMember]
            public bool Result { get; set; }
        }
        public class Pets
        {
            [XmlElement(ElementName = "Dog")]
            public string[] Dogs;
            [XmlElement(ElementName = "Cat")]
            public string[] Cats;
        }
        static Binding GetBinding()
        {
            var result = new BasicHttpBinding();
            return result;
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), GetBinding(), "");
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(GetBinding(), new EndpointAddress(baseAddress));
            ITest proxy = factory.CreateChannel();
            Pets pets = new Pets { Cats = new string[] { "Max" }, Dogs = new string[] { "Fido", "Duke" } };
            proxy.SavePets(new SavePetsRequest { Pets = pets });
            ((IClientChannel)proxy).Close();
            factory.Close();
            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "text/xml";
            c.Headers["SOAPAction"] = "urn:ITest/SavePets";
            string reqBody = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <s:Body>
                        <Pets>
                            <Dog>Fido</Dog>
                            <Dog>Duke</Dog>
                            <Cat>Max</Cat>
                        </Pets>
                    </s:Body>
                </s:Envelope>";
            Console.WriteLine(c.UploadString(baseAddress, reqBody));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

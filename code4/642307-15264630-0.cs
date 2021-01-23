    public class StackOverflow_15252991
    {
        [DataContract(Name = "TestRequest", Namespace = "http://www.mysite.com/Test")]
        public class TestRequest
        {
            [DataMember(Order = 2)]
            public int ID { get; set; }
            [DataMember(Order = 1)]
            public InnerTestRequest InnerTestRequest { get; set; }
        }
        [DataContract(Name = "InnerTestRequest", Namespace = "http://www.mysite.com/Test")]
        public class InnerTestRequest
        {
            [DataMember]
            public int ID { get; set; }
        }
        [DataContract(Namespace = "http://www.mysite.com/Test", Name = "TestResponse")]
        public class TestResponse
        {
            [DataMember]
            public int ID { get; set; }
        }
        [ServiceContract(Namespace = "http://www.mysite.com/Test")]
        public interface ITestService
        {
            [OperationContract]
            [WebInvoke]
            TestResponseContract Test(TestRequestContract request);
        }
        [MessageContract(IsWrapped = false)]
        public class TestRequestContract
        {
            [MessageBodyMember]
            public TestRequest TestRequest { get; set; }
        }
        [MessageContract(IsWrapped = false)]
        public class TestResponseContract
        {
            [MessageBodyMember]
            public TestResponse TestResponse { get; set; }
        }
        public class Service : ITestService
        {
            public TestResponseContract Test(TestRequestContract request)
            {
                return new TestResponseContract { TestResponse = new TestResponse { ID = request.TestRequest.ID } };
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITestService), new BasicHttpBinding(), "soap");
            host.AddServiceEndpoint(typeof(ITestService), new WebHttpBinding(), "rest").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            var factory = new ChannelFactory<ITestService>(new BasicHttpBinding(), new EndpointAddress(baseAddress + "/soap"));
            var proxy = factory.CreateChannel();
            var input = new TestRequestContract { TestRequest = new TestRequest { InnerTestRequest = new InnerTestRequest { ID = 2 }, ID = 4 } };
            Console.WriteLine(proxy.Test(input).TestResponse.ID);
            ((IClientChannel)proxy).Close();
            factory.Close();
            factory = new ChannelFactory<ITestService>(new WebHttpBinding(), new EndpointAddress(baseAddress + "/rest"));
            factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Test(input).TestResponse.ID);
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.WriteLine();
            Console.WriteLine("Now using the inputs from the OP");
            foreach (bool useSoap in new bool[] { true, false })
            {
                WebClient c = new WebClient();
                c.Headers[HttpRequestHeader.ContentType] = "text/xml";
                if (useSoap)
                {
                    c.Headers["SOAPAction"] = "http://www.mysite.com/Test/ITestService/Test";
                }
                string uri = useSoap ?
                    baseAddress + "/soap" :
                    baseAddress + "/rest/Test";
                Console.WriteLine("Request to {0}", uri);
                string body = @"<TestRequest xmlns=""http://www.mysite.com/Test"">
                                    <InnerTestRequest>
                                        <ID>2</ID>       
                                    </InnerTestRequest>
                                    <ID>4</ID>
                                </TestRequest>";
                if (useSoap)
                {
                    body = "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body>" +
                        body +
                        "</s:Body></s:Envelope>";
                }
                Console.WriteLine(c.UploadString(uri, body));
                Console.WriteLine();
            }
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

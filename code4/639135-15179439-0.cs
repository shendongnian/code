    public class StackOverflow_15173138
    {
        [ServiceContract(Namespace = "http://www.test.org/test/2007/00")]
        public interface IService1
        {
            [OperationContract]
            MyResponse GetData(MyRequest request);
        }
        public class Service1 : IService1
        {
            public MyResponse GetData(MyRequest request)
            {
                return new MyResponse
                {
                    TestReply = new GetDataResponse
                    {
                        Result = new Result { ActionSuccessful = true },
                        ResultData = new ResultData { Name = request.name }
                    }
                };
            }
        }
        [MessageContract(IsWrapped = false)]
        public class MyResponse
        {
            [MessageBodyMember]
            public GetDataResponse TestReply { get; set; }
        }
        [MessageContract(WrapperName = "GetData")]
        public class MyRequest
        {
            [MessageBodyMember]
            public string name { get; set; }
        }
        [DataContract(Namespace = "http://www.test2.org/test2/types")]
        public class GetDataResponse
        {
            [DataMember(Name = "Result")]
            public Result Result { get; set; }
            [DataMember(Name = "ResultData")]
            public ResultData ResultData { get; set; }
        }
        [DataContract(Namespace = "http://www.test2.org/test2/types")]
        public class Result
        {
            [DataMember(Name = "ActionSuccessful")]
            public bool ActionSuccessful { get; set; }
        }
        [DataContract(Namespace = "http://www.test2.org/test2/types")]
        public class ResultData
        {
            [DataMember(Name = "Name")]
            public string Name { get; set; }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service1), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(), "");
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            IService1 proxy = factory.CreateChannel();
            Console.WriteLine(proxy.GetData(new MyRequest { name = "hello" }));
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }

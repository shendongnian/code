    [ServiceContract]
        public interface IMyService
        {
            [OperationContract]
            MyResponse DoSomething(MyRequest request);
        }
    
        public class MyService : IMyService
        {
            public MyResponse DoSomething(MyRequest request)
            {
                return new MyResponse()
                {
                    Details = "Service did something awesome.",
                    Timestamp = DateTime.Now
                };
            }
        }
    
        [MessageContract(IsWrapped = true, WrapperNamespace = "http://myservice/messages/")]
        public class MyRequest
        {
            [MessageHeader(Namespace = "http://myservice/security")]
            public string TokenThingy
            {
                get;
                set;
            }
        }
    
        [MessageContract(IsWrapped = true, WrapperNamespace = "http://myservice/messages")]
        public class MyResponse
        {
            [MessageBodyMember]
            public string Details
            {
                get;
                set;
            }
    
            [MessageBodyMember]
            public DateTime Timestamp
            {
                get;
                set;
            }
        }

    namespace yourNS
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebGet(UriTemplate = "/CT", ResponseFormat = WebMessageFormat.Json)]
            List<CompositeType> GetData();
        }
    
    
        [DataContract]
        public class CompositeType
        {
            [DataMember]
            public bool BoolValue { get; set; }
    
            [DataMember]
            public string StringValue { get; set; }
        }
    
        public class Service1 : IService1
        {
            public List<CompositeType> GetData()
            {
                return new List<CompositeType>
                {
                    new CompositeType { BoolValue = true, StringValue = "blah" },
                    new CompositeType { BoolValue = false, StringValue = "boo" },
                    new CompositeType { BoolValue = true, StringValue = "floo" },
                };
            }
        }
    }

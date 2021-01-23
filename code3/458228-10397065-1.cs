    namespace WcfService1
    {
        [DataContract]
        public class Request
        {
            [DataMember]
            public string Param1 { get; set; }
            [DataMember]
            public long Param2 { get; set; }
            [DataMember]
            public Stream Param3 { get; set; }
        }
    }

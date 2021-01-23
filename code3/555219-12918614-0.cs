    public class Contract
    {
        [DataMember]
        public int clientId;
        [DataMember]
        public JsonObj json;
    }
    public class JsonObj
    {
        [DataMember]
        public string test;
    }

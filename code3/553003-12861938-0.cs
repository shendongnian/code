    [DataContract]
    public class MyResponse
    {
        [DataMember]
        public bool IsSuccessful { get { return Message == null || !Messages.Any(); } set { } }
        [DataMember]
        public List<string> Messages { get; set; }
    }

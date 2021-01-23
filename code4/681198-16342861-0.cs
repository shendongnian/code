    [DataContract]
    public class Cono
    {
        [DataMember(Order = 1)]
        public Companies[] companies;
        [DataMember(Order = 2)]
        public Error error;    
    }
    public class Error
    {
        public int code;
        public string message;
    }

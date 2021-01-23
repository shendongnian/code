    [DataContract]
    public class MyFunctionResult
    {
        [DataMember]
        public Boolean Result { get; set; }
        [DataMember]
        public String ErrorMessage { get; set; }
    }

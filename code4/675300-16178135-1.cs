    [DataContract]
    public class Dto
    {
        [DataMember(Order=i)]
        public string PropertyName { get; set; }
    }
    [ProtoContract]
    public class Dto
    {
        [ProtoMember(i)]
        public string PropertyName { get; set; }
    }

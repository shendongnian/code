    [DataContract(Namespace="http://mynamespace.com")]
    public class MyDataContract
    {
        [DataMember(IsRequired=true)]
        public MyCustomPartsCollection CustomParts { get; set; }
    
    }

    [DataContract]
    public class MyType
    {
        // This property is serialized to the client.
        [DataMember]
        public int MyField1 { get; set; }
        // This property is NOT serialized to the client.
        public string MyField2 { get; set; }
    }

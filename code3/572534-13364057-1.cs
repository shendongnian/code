    [DataContract]
    public partial class SerializableFoo
    {
        [DataMember]
        public string MyString { get; set; }
        [DataMember]
        public int MyInt { get; set; }
        [DataMember]
        public string MyBar { get; set; }
    }

    [DataContract]
    public class DeserializedObject
    {
        [DataMember(Name = "size")]
        public UInt64 Size { get; set; }
        [DataMember(Name = "location")]
        public string Location { get; set; }
        [DataMember(Name = "report")]
        public Dictionary<string, string[]> Report { get; set; } 
    }

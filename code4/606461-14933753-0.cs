    [DataContract(Name = "response", Namespace = "http://domain.com/name")]
    public class MyResponseClass 
    {
        [DataMember(Name = "count", IsRequired = true, Order = 0, EmitDefaultValue = false)]
        public int Count { get; set; }
    
        [DataMember(Name = "info", IsRequired = false, Order = 1, EmitDefaultValue = false)]
        public InfoClass Info { get; set; }
    
        [DataMember(Name = "metadata", IsRequired = false, Order = 2, EmitDefaultValue = false)]
        public MetadataList Metadatas { get; set; }
    }

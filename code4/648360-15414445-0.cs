    [DataContract(Name = "PROPERTY_ADDRESS", Namespace = "")]
    public class PropertyAddress
    {
        [DataMember(Name = "STREET_NUM", Order=1)]
        public string StreetNumber { get; set; }
    
        [DataMember(Name = "STREET_ADDRESS", Order=2)]
        public string StreetAddress { get; set; }
    
        [DataMember(Name = "STREET_PREFIX", Order=3)]
        public string StreetPrefix { get; set; }
    
        [DataMember(Name = "STREET_NAME", Order=4)]
        public string StreetName { get; set; }
    
        [DataMember(Name = "STREET_TYPE", Order=5)]
        public string StreetType { get; set; }
    
        [DataMember(Name = "STREET_SUFFIX", Order=6)]
        public string StreetSuffix { get; set; }
    }

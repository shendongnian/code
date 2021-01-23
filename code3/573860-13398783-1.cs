    [DataContract]
    public class CountryInfo
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name = "schengen", EmitDefaultValue = false)
        public bool? Schengen { get; set; }
    }

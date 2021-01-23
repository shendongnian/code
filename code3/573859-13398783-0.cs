    [DataContract]
    public class CountryInfo
    {
        [DataMember(Name = "country")]
        public string County { get; set; }
        [DataMember(Name = "schengen", EmitDefaultValue = false)
        public bool? Schengen { get; set; }
    }

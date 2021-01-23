    [DataContract]
    public class Center
    {
        [DataMember(Name = "center_name")]
        public string Name { get; set; }
        [DataMember(Name = "special_notes")]
        public string SpecialNotes { get; set; }
        [DataMember(Name = "address")]
        public Address Address { get; set; }
        public Center() { this.Address = new Address();}
    }
    [DataContract]
    public class Address
    {
        [DataMember(Name = "street_name")]
        public string StreetName { get; set; }
        [DataMember(Name = "suburb")]
        public string Suburb { get; set; }
        [DataMember(Name = "state")]
        public string State { get; set; }
        [DataMember(Name = "postcode")]
        public string Postcode { get; set; }
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
    }

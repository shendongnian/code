    [DataContract]
     public class Place
     {
        [DataMember(Name = "location")]
        public Location Locations { get; set; }
        [DataMember(Name = "category")]
        public string Category { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "id")]
        public string ID { get; set; }
    }

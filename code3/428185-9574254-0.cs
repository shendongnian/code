    [DataContract]
    class PoiList
    {
        [DataMember]
        public List<PoiPoi> Pois { get; set; }
    }
    [DataContract]
    class PoiPoi
    {
        [DataMember]
        public Poi poi { get; set; }
    }
    
    [DataContract]
    class Poi
    {
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string latitude { get; set; }
        [DataMember]
        public string longitude { get; set; }
    }

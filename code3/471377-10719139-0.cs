    [XmlRoot("profileSite")]
    public class ProfileSite
    {
        [XmlAttribute("profileId")] 
        public int ProfileId { get; set; }
    
        [XmlAttribute("siteId")] 
        public int SiteId { get; set; }
    
        [XmlArray("links"), XmlArrayItem("link")]    
        public Link[] Links { get; set; }
    
    }
    
    public class Link
    {
        [XmlElement("originalUrl")]
        public string OriginalUrl{get;set;}
        // You other props here much like the above
    }

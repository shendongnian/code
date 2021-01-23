     [XmlAttribute("lastUpdated")]
     public DateTime? LastUpdated { get; set; } 
     public bool LastUpdatedSpecified
     {
         get { return LastUpdate.HasValue; }
     }

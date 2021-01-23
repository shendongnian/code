     [XmlType("ContactInfo")]
     public class ContactInfo
     {
        [XmlElement("OnlineResource")]
        public OnlineResource Resource { get; set; }
     }
    
     [XmlType("OnlineResource")]
     public class OnlineResource
     {
         [XmlAttribute("href")]
         public string href = "mailto:enquiry@gis.nottscc.gov.uk";
     }

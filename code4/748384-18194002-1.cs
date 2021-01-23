    [XmlRoot("CarrierService.GetAlerts")] 
    public class GetAlertsResponse
    {
        [XmlElement(ElementName = "ResponseDO")]
        public ResponseDo ResponseDo { get; set; }
    
        [XmlArray(ElementName = "AlertList")]
        public List<AlertItem> AlertList { get; set; }
    }
    public class AlertItem
    {
        [XmlElement(ElementName = "docketNumber")]
        public string DocketNumber { get; set; }
    
        [XmlElement(ElementName = "dotNumber")]
        public string DOTNumber { get; set; }
    
        [XmlElement(ElementName = "Changes")]
        public Changes Changes { get; set; }
    }
    public class Changes
    {
        [XmlElement(ElementName = "Change")]
        public  List<Change> ChangesList { get; set; }
    }
    public class Change
    {
        [XmlElement("Field")]
        public string Field {get; set;}
    
        [XmlElement("From")]
        public string From {get; set;}
    
        [XmlElement("To")]
        public string To {get; set;}
    }

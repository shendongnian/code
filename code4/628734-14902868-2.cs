    public class sta
    {
        public int db { get; set; }
        public int hz { get; set; }
        
        [XmlAttribute()]
        public string station { get; set; }
    }
    public class frm
    {
        [XmlAttribute("frm")]
        public string frmID { get; set; }
        [XmlElement("sta")]
        public List<sta> stas { get; set; }
    }
    public class icao
    {
        [XmlAttribute]
        public string icaoID { get; set; }
        [XmlElement("frm")]
        public List<frm> frms { get; set; }
    }
    public class EarObs
    {
        [XmlAttribute]
        public string EventId { get; set; }
        [XmlElement("icao")]
        public List<icao> icaos { get; set; }
    }

    public class MovieRunTimes
    {
        [XmlElement("ShowDate")]
        public string ShowDate { get; set; }
        [XmlElement("TicketURI")]
        public string TicketUri { get; set; }
        [XmlArray("ShowTimesByDate")]
        [XmlArrayItem(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<string> ShowTimesByDate { get; set; }
    }

    [XmlRoot("Show")]
    public class Show
    {
        [XmlElement(ElementName = "status")]
        public ShowStatus status { get; set; }
    }
    public enum ShowStatus
    {
        [XmlEnum("2")]
        Canceled = 2
    }

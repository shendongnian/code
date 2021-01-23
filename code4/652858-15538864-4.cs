    [XmlType]
    public class Conditions
    {
        [XmlText]
        public DateTime? OpenedSince { get; set; }
        [XmlText]
        public DateTime? AddedUntil { get; set; }
        [XmlText]
        public DateTime? OpenedUntil { get; set; }
        [XmlText]
        public DateTime? ArchivedUntil { get; set; }
        public string NotTobeListed { get; set; }
    }

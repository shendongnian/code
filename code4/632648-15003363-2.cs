    public class NotificationType
    {
        [XmlIgnore] // required
        public NotificationTypeRefname refname { get; set; }
        [XmlIgnore] // required
        public NotificationTypeShortname shortname { get; set; }
        [XmlIgnore] // required
        public SourceTypeCode sourcetype { get; set; }
        //[XmlText] // optional
        public List1 Value { get; set; }
    }

    public partial class NotificationType
    {
        public NotificationTypeRefname refname { get; set; }
        public NotificationTypeShortname shortname { get; set; }
        public SourceTypeCode sourcetype { get; set; }
        public List1 Value { get {
            return (List1)Enum.Parse(typeof(List1), 
                Enum.GetName(typeof(List1), int.Parse(List1Value) - 1));
        }}
        [XmlText]
        public string List1Value { get; set; }
    }

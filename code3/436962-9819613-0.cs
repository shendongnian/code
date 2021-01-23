    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Events
    {
        [XmlElement("Event", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public EventType[] Items
        {
            get;
            set;
        }
    }

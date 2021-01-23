<!-- -->
    public class Event
    {
        [XmlArrayItem(ElementName = "Data")]
        public EventData[] EventData;
    }
    public class EventData
    {
        [XmlAttribute]
        public string Name;
        [XmlText]
        public string Value;
    }

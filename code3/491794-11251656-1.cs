<!-- -->
    public class Event
    {
        public Data[] EventData;
    }
    public class Data
    {
        [XmlAttribute]
        public string Name;
        [XmlText]
        public string Value;
    }

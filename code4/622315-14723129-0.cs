    [XmlRoot("radio")]
    public sealed class radio
    {
        [XmlElement("channel", Type = typeof(channel))]
        public channel[] channels { get; set; }
        [XmlElement("programme", Type = typeof(programme))]
        public programme[] programmes { get; set; }
        public radio()
        {
            channels = null;
            programmes = null;
        }
        public static radio FromXmlString(string xmlString)
        {
            var reader = new StringReader(xmlString);
            var serializer = new XmlSerializer(typeof(radio));
            var instance = (radio)serializer.Deserialize(reader);
            return instance;
        }
    }
    [Serializable]
    public class channel
    {
        [XmlAttribute("id")]
        public string id { get; set; }
        [XmlElement("display-name")]
        public string displayName { get; set; }
        [XmlElement("icon")]
        public string icon { get; set; }
        public channel()
        {
        }
    }
    [Serializable]
    public sealed class programme
    {
        [XmlAttribute("channel")]
        public string channel { get; set; }
        [XmlAttribute("start")]
        public string start { get; set; }
        [XmlAttribute("stop")]
        public string stop { get; set; }
        [XmlAttribute("duration")]
        public string duration { get; set; }
        [XmlElement("title")]
        public string title { get; set; }
        [XmlElement("desc")]
        public string desc { get; set; }
        [XmlElement("category")]
        public string category { get; set; }
        [XmlElement("date")]
        public string date { get; set; }
        public programme()
        {
        }
    }

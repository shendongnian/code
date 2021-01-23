    public class ShortcutBinding
    {
        public ShortcutHandler ShortcutHandler { get; set; }
    }
    public class ShortcutHandler
    {
        [XmlAttribute]
        public string Name { get; set; }
                
        [XmlElement("Shortcut")]
        public List<Shortcut> Shortcuts { get; set; }
    }
    public class Shortcut
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement("Key")]
        public List<string> Keys { get; set; }
    }

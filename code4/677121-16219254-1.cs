        [XmlRoot("Config")]
        public class ConfigSerializer
        {
            [XmlArray("Nodes"),XmlArrayItem("N")]
            public List<Node> LstNodes { get; set; }
        }

    [Serializable]
    [XmlRoot("manifest")]
    public class Manifest
    {
        [XmlElement("list")]
        public List<FeatureList> FeatureLists { get; set; }
        [XmlAttribute("attr")]
        public string Attr { get; set; }
        [XmlAttribute("attr2")]
        public string Attr2 { get; set; }
        [XmlAttribute("attr3")]
        public string Attr3 { get; set; }
    }
    [Serializable]
    public class FeatureList
    {
        [XmlElement("feature")]
        public List<Feature> Features { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("attr")]
        public string Attr { get; set; }
    }
    [Serializable]
    public class Feature
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("attr")]
        public string Attr { get; set; }
    }

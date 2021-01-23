    [XmlRoot("Bar1", Namespace = "http://example.com/schemas/Bar1")]
    public class Bar1
    {
        [XmlRoot("Bar1EnumSameName", Namespace = "http://example.com/schemas/Bar1")]
        public enum EnumSameName
        {
            a
        }
        public EnumSameName Mode { get; set; }
    }
    [XmlRoot("Bar2", Namespace = "http://example.com/schemas/Bar2")]
    public class Bar2
    {
        [XmlRoot("Bar2EnumSameName", Namespace = "http://example.com/schemas/Bar2")]
        public enum EnumSameName
        {
            b
        }
        public EnumSameName Mode { get; set; }
    }

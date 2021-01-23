    [XmlRoot(ElementName = "a")]
    public class A
    {
        [XmlElement(ElementName = "b")]
        public int? B { get; set; }
        [XmlElement(ElementName = "c")]
        public string _c { get; set; }
        public int? C
        {
            get
            {
                int retval;
                return !string.IsNullOrWhiteSpace(_c) && int.TryParse(_c, out retval) ? (int?) retval : null;
            }
        }
    }

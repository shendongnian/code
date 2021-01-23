    [Serializable]
    [XmlType("property")]
    public class Property
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("value")]
        public string StringValue { get; set; }
        private object _Value;
        [XmlIgnore]
        public object Value
        {
            get
            {
                if (_Value == null)
                {
                     _Value = CreateFromStringValue();
                }
                return _Value;
            }
        }
        public Property()
        {
        }
        private object CreateFromStringValue()
        {
           // parse StringValue in here as you see fit (e.g. first try bool, then int, float, etc.)
        }
    }

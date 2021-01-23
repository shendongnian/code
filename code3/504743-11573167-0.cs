    static void Main(string[] args)
            {
                var serialized = @"
    <tx size_total=""143""> 
      <type size=""1"" start_key=""02"">STX</type> 
      <type size=""3"">Type</type> 
      <type size=""3"" decimal=""true"">Serial</type> 
      <type size=""3"" key=""23 64 31"">Function_Code</type> 
      <type size=""2"" decimal=""true"">LIU</type> 
      <type size=""1"">Status</type> 
      <type size=""2"" repeat=""64"" binary =""true"" binary_discard=""2"">Value</type> 
      <type size=""1"">ETX</type> 
      <type size=""1"">LRC</type></tx>";
                var deserialized = serialized.XmlDeserialize<Tx>();
            }
        }
    
        [XmlRoot("tx")]
        public class Tx
        {
            [XmlAttribute("size_total")]
            public int TotalSize { get; set; }
    
            [XmlElement("type")]
            public List<TxType> Types { get; set; }
    
            public Tx()
            {
                Types = new List<TxType>();
            }
        }
    
        public class TxType
        {
            [XmlAttribute("size")]
            public string Size { get; set; }
    
            [XmlAttribute("decimal")]
            public bool IsDecimal { get; set; }
    
            [XmlAttribute("binary")]
            public bool IsBinary { get; set; }
    
            [XmlAttribute("start_key")]
            public string StartKey { get; set; }
    
            [XmlAttribute("key")]
            public string Key { get; set; }
    
            [XmlAttribute("repeat")]
            public int Repeat { get; set; }
    
            [XmlAttribute("binary_discard")]
            public int BinaryDiscard { get; set; }
    
            [XmlText]
            public string Value { get; set; }
        }

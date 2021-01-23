    [Serializable]
    [XmlType(AnonymousType=true)]
    [XmlRoot(Namespace="", IsNullable=false)]
    public partial class select {
        
        [XmlElement("option")]
        public selectOption[] option { get; set; }
        
        /// <remarks/>
        [XmlAttribute]
        public string disablesorting { get; set; }
    }
    
    [System.Serializable]
    [XmlType(AnonymousType=true)]
    public partial class selectOption {
        
        [XmlAttribute]
        public string attrib1 { get; set; }
        
        [XmlAttribute]
        public string attrib2 { get; set; }
        
        [XmlText]
        public string Value { get; set; }
    }
    
    [System.Serializable]
    [XmlType(AnonymousType=true)]
    [XmlRoot(Namespace="", IsNullable=false)]
    public partial class NewDataSet {
        
        [XmlElement("select")]
        public select[] Items { get; set; }
    }

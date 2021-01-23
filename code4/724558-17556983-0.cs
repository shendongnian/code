    [XmlInclude(typeof(TypeA))]
    [XmlInclude(typeof(TypeB))]
    class BaseType
    {
        public string CommonData { get; set; }
    }
    
    class TypeA : BaseType
    {
        public string TypeASpecificData { get; set; }
    }
    
    class TypeB : BaseType
    {
        public string TypeBSpecificData { get; set; }
    }

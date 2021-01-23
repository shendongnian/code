    public class ClassToSerialize
    {
        [XmlAttribute("attributeName")]
        public EnumType EnumPropertyValue
        {
            get { return EnumProperty.Value; }
            set { EnumProperty = value; }
        }
        [XmlIgnore]
        public EnumType? EnumProperty { get; set; }
        public bool EnumPropertyValueSpecified => EnumProperty.HasValue;
    }

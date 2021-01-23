    [System.SerializableAttribute()] // useless, valuetype is implicitly so
    public enum MyEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("035")]
        Item1,
        Item2
    }

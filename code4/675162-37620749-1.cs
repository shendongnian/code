    [Serializable]
    [XmlRoot(ElementName = "foo")]
    public class foo
    {
       [XmlElement(ElementName = "myInteger", isNullable = false)]
       Optional<int> myInt;
    }

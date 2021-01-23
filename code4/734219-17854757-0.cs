    [XmlArray("images")]
    [XmlElementAttribute(Type = typeof(Bonusimage))]
    [XmlElementAttribute(Type = typeof(CustomImageClass))]
    public CustomImageClass[] items;
    
    [XmlType("bonusimage")]
    public class Bonusimage: CustomImageClass
    {
    }
    [XmlType("image")]
    public class CustomImageClass
    {
    }

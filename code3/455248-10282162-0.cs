    public struct XmlPerson
    {
        [XmlAttribute] public string Id   { get; set; }
        [XmlAttribute] public string Name { get; set; }
    }
    public class GroupOfPeople
    {
        [XmlArray]
        [XmlArrayItem(ElementName="XmlPerson")]
        public List<XmlPerson> XmlPeople { get; set; }
    }

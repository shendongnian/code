    [Serializable]
    public class MyClass : IXmlSerializable
    {
        public MySubClass SubClass { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Name");
            writer.WriteString(SubClass.Name);
            writer.WriteEndAttribute();
            writer.WriteStartAttribute("Phone");
            writer.WriteString(SubClass.Phone);
            writer.WriteEndAttribute();
        }
    }
    [Serializable]
    public class MySubClass
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

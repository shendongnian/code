    public class Items1
    {
        [XmlAttribute]
        public string note { get; set; }
        [XmlElement]
        public List<item1> item1 { get; set; }
    }
    public class Item2
    {
        [XmlElement]
        public List<item2> item2 { get; set; }
    }
    [XmlRootAttribute("Something", Namespace="", IsNullable=false)]
    public class Something
    {
       [XmlElement]
        public Items1 items1 { get; set; }
        [XmlElement]
        public Item2 item2 { get; set; }
    }
    Something objSomething = this.Something();
    ObjectXMLSerializer<Something>.Save(objSomething, FILE_NAME);
    Loading the xml
    objSomething = ObjectXMLSerializer<Something>.Load(FILE_NAME);

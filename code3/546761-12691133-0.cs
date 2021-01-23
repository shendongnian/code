    [XmlRoot("NameCollection")]
    public class NameCollection
    {
        public string GenericName {get;set:}
        public string GenericDescription {get;set:}
        [XmlArray("Names")]
        [XmlArrayItem("Name", typeof(TestCommand))]
        public TestCommand[] TestCommand {get;set;}
    }

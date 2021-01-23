    public class TestCommand
    {
       public string description{get;set;}
    }
    [XmlRoot("NameCollection")]
    public class NameCollection
    {
        public string GenericName {get; set;}
        public string GenericDescription {get; set;}
    
       [XmlArray("Commands")]
       [XmlArrayItem("Command", typeof(TestCommand))]
       public TestCommand[] TestCommand {get;set;}
    }

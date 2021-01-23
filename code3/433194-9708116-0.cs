    void Main()
    {
        string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <Animals>
            <Animal>
                <Name>Cow</Name>
                <Color>Brown</Color>
            </Animal>
        </Animals>";
        
        XmlReader reader = XmlReader.Create(new StringReader(xml));
    
        XmlSerializer ser = new XmlSerializer(typeof(Model));
    
        var list = (Model)ser.Deserialize(reader);
        list.Dump();
    }
    
    // Define other methods and classes here
    [XmlRoot("Animals")]
    public class Model
    {
        [XmlElement("Animal")]
        public List<Animal> AnimalList { get; set; }
    }
    
    public class Animal
    {
        [XmlElement("Name")]
        public string Name{ get; set; }
        [XmlElement("Color")]
        public string Color{ get; set; }
    }

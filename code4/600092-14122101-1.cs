    public class ExportDefinition
    {
       [XmlElement]
       public string DestinationDir { get; set; }
    
       [XmlElement]
       public string LevelID { get; set; }
    
       private List<Field> list = new List<Field>();
    
       [XmlArray("Metadata")]
       [XmlArrayItem("Field")]
       public List<Field> Items { get { return list; } }
    }

    [Serializable]
    public class ValueWithId
    {
       [XmlAttribute ("id")]
       public long? Id { get; set; }
    
       [XmlText]  // Also tried with [XmlElement]
       public string Description { get; set; }
    }

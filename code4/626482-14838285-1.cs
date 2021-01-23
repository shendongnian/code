    [Serializable]
    public class ValueWithId
    {
       [XmlAttribute ("id")]
       public long Id { get; set; }
    
       [XmlText] 
       public string Description { get; set; }
    }

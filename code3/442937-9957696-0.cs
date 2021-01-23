    using System.Linq;
    
    ...
    
    [XmlIgnore]
    public Field[][] Fields;
    [XmlArray("Fields")]
    public Field[] SerializedFields
    {
        get
        {
            return this.Fields.SelectMany(fields => fields).ToArray();
        }
        set
        {
            // To be implemented...
        }
    }

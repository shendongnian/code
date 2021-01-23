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
            this.Fields = value.GroupBy(field => field.x).Select(g => g.ToArray()).ToArray();
        }
    }

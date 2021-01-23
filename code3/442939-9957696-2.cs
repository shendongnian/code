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
            this.Fields = new Field[value.Max(field => field.x) + 1][];
            for (int x = 0; x < this.Fields.Length; x++)
            {
                this.Fields[x] = value.Where(field => field.x == x).ToArray();
            }
        }
    }

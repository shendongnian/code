    [XmlIgnore]
    public ObjectId _id { get; set; }
    
    public string MongoId
    {
        get { return _id.ToString(); }
        set { _id = ObjectId.Parse(value); }
    }

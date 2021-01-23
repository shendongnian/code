    [XmlElement("target", IsNullable = true)]
    public string TempProperty { get; set; }
    
    [XmlIgnore]
    public bool Target
    {
        get
        {
            return this.TempProperty != null;
        }
    }

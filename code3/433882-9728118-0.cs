    [XmlIgnore()]
    public float SomeValue { get; set; }
    
    [XmlAttribute("SomeValue")]
    public float SomeValueRounded
    {
        get { return (float)Math.Round(SomeValue, 2); }
        set { SomeValue = value; }
    }

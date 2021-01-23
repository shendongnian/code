    [XmlIgnore]
    public char TestProperty { get; set; }
    [XmlElement("Test"), Browsable(false)]
    public string TestPropertyString {
        get { return TestProperty.ToString(); }
        set { TestProperty = value.Single(); }
    }

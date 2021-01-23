    //this property would not be serialized if it contains String.Empty value
    public string PropertyName   {   get; set;  }
    [XmlIgnore]
    public bool PropertyNameSpecified
    {
        get  { return PropertyName != String.Empty; }
    }

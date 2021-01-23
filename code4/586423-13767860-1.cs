    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore]
    public System.DateTime date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("date", Order = 0)]
    public System.String somedate
    {
        get { return this.date.ToString("yyyy'-'MM'-'dd'Z'"); }
        set { this.date = System.DateTime.Parse(value); }
    }

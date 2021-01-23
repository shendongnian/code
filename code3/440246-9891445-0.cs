    [XmlIgnore]
    public DateTime startDate { get;set;}
    
    [XmlElement("startDate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string startDateXml
    {
        get { return startDate.ToString("the format you want"; }
        set { startDate = DateTime.ParseExact(value, "the format you want", null); }
    }

    [XmlIgnore]
    public DateTime startDate { get;set;}
    
    private const string DateTimeFormat = "ddd, dd MMM yyyy HH:mm:ss";
    [XmlElement("startDate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string startDateXml
    {
        get { return startDate.ToString(DateTimeFormat, CultureInfo.InvariantCulture); }
        set { startDate = DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture); }
    }

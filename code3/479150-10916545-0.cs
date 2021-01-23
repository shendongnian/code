    [XmlIgnore]
    public string Designation { get; set; }
    
    [XmlElement("span")]
    public XmlNode DesignationAsXml
    {
        get
        {
            XmlDocument doc = new XmlDocument();
            doc.InnerXml = "<root>" + this.Designation + "</root>";
            return doc.DocumentElement.FirstChild;
        }
        set
        {
            throw new NotSupportedException();
        }
    }

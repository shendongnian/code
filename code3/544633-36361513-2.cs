    [XmlType]
    public string XmlString { get; set; }
    [NotMapped]
    public XElement Xml
    {
        get { return !string.IsNullOrWhiteSpace(XmlString) ? XElement.Parse(XmlString) : null; }
        set {
            XmlString = value == null ? null : value.ToString(SaveOptions.DisableFormatting);
        }
    }

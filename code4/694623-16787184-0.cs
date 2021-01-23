    [XmlIgnore]
    public DateTime Time { get; set; }
    [XmlElement("Time")]
    public string strTime
    {
            get { return Time.ToString("o"); }
            set { Time = DateTime.Parse(value); }
    }

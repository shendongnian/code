    [XmlIgnore]
    public DateTime _time {
        get { return DateTime.ParseExact(this.time, "MM/dd/YYYY HH:mm", CultureInfo.InvariantCulture);} // or use some specific culture here.
    }
    [XmlElement]
    public string time { get; set; }

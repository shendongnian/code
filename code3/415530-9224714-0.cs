    [XmlIgnore]
    public List<string> CardList { get; private set; }
    [XmlAttribute("cards")]
    public string Cards {
       get { return String.Join(",", CardList); }
       set { CardList = value.Split(",").ToList(); }
    }

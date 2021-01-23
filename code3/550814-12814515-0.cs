    [XmlIgnore]
    public double Price { get;set; }
    
    [XmlElement("Price")]
    public string PriceString {
        get {return Price.ToString();}
        set {Price = double.Parse(value);}
    }

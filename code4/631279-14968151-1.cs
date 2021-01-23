    static CultureInfo ci = CultureInfo.InvariantCulture;
    float _TotalInclTax = 0;
    [XmlIgnore]
    public float TotalInclTax 
    {
        get { return _TotalInclTax ; }
        set { _TotalInclTax  = value; }
    }
    [XmlElement("TotalInclTax")]
    public string CustomTotalInclTax
    {
        get { return TotalInclTax.ToString("#0.00", ci); }
        set { float.TryParse(value, NumberStyles.Float, ci, out _TotalInclTax); }
    }

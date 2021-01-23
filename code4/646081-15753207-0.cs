    // For property grid only:
    [Category(CategoryAnalyse)]
    [TypeConverter(typeof(ConverterBoolOnOff))]
    [DefaultValue(false)]
    [XmlIgnore]
    public bool AllowNegative
    {
        get { return _allowNegative; }
        set
        {
            _allowNegative = value;
            ConfigBase.OnConfigChanged();
        }
    }
    // For serialization:
    [Browsable(false)]
    [TypeConverter(typeof(ConverterBoolOnOff))]
    [XmlElement("AllowNegative")]
    public bool AllowNegative_XML
    {
        get { return _allowNegative; }
        set
        {
            _allowNegative = value;
            ConfigBase.OnConfigChanged();
        }
    }

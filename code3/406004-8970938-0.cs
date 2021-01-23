    // Disclaimer: Untested
    [Flags]      
    public enum InfoAbonne 
    {
        civilite = 0x1, // Increment each flag value by *2 so they dont conflict
        Name=0x2,
        firstname=0x4,
        email=0x8,
        adress=0x10,
        country=0x20 
    }  
    // Don't serialize this
    [XmlIgnore]
    private InfoAbonne _infoAbonne { get; set;} 
    // Instead serialize this. 
    // e.g. name | email will equal 1010b or 0xA in hex, or 10 in dec
    [XmlElement("InfoAbonne")]
    private InfoAbonneSerializer 
    { 
        get { return (int)_infoAbonne; } 
        set { _infoAbonne= (InfoAbonne) value; } 
    } 

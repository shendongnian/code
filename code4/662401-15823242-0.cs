    public enum DwellingType { Apartment, Cottage, House }
    
    public DwellingType DwellingType { get; set; } // This wont be mapped in EF4 as it's an enum
    
    public virtual string DwellingTypeString       // This will be mapped
    {
        get { return DwellingType.ToString(); }
        set
        {
            DwellingType stringValue;
            if(Enum.TryParse(value, out stringValue))
            { DwellingType = stringValue; }
        }
    }

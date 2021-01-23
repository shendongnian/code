    public const string GrossAmountPropertyName = "GrossAmount";
    private double _grossAmount;
    public double GrossAmount
    {
        get { return _grossAmount; }
        set 
        {
               if (_grossAmount == value)
                    return;
    
               RaisePropertyChanged(GrossAmountPropertyName);
               RaisePropertyChanged(NetAmountPropertyName);
        }
    }
    
    public double Discount{} ... //Implement same as above
    public double Carriage {} ... //Implement same as above
    
    public const string NetAmountPropertyName = "NetAmount";
    public double NetAmount
    {
        get { return GrossAmount + Carriage - Discount; }
    }

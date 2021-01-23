    private string _unitType;
    public string UnitType 
    {
        get { return _unitType; }
        set
        {
            _unitType = value;
            Weight = (_unitType ?? "").Equals("Weight", StringComparison.CurrentCultureIgnoreCase);
            Quantity = (_unitType ?? "").Equals("Quantity", StringComparison.CurrentCultureIgnoreCase);
        }
    }

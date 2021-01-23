    public string dt
    {
        get { return _datevalue.ToString(); }
        set { if(!DateTime.TryParse(value, out _datevalue)) /* Error recovery!! */ ;}
    }

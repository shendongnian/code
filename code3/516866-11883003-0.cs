    public int _typeId;
    
    public int TypeId 
    {
        get
        {
            return _typeId;
        }
        set
        {
            _typeId = value;
            isApproved = value != 1;
        }
    }

    private string _name;
    
    public getName { return _name; }
    public setName(string value) 
    { 
        if (value == null) return; //Don't want things setting my Name to null
        _name = value; 
    }

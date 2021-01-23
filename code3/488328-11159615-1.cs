    private string _name;
    
    public getName { return _name; }
    public setName(string value) 
    { 
        //Don't want things setting my Name to null
        if (value == null) 
        {
            throw new InvalidInputException(); 
        }
        _name = value; 
    }

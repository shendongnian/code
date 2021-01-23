    private string _name;
    
    public string getName { return _name; }
    public void setName(string value) 
    { 
        //Don't want things setting my Name to null
        if (value == null) 
        {
            throw new InvalidInputException(); 
        }
        _name = value; 
    }

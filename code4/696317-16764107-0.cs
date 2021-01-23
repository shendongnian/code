    private string _name;
    public string Name  {
        get { return _name; }
        set { if(_name.Length > 3) _name = value; } 
    }

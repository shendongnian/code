    private List<string> _namesList = new List<string>();
    // list of names
    public List<string> NamesList
    {    
        get
        {
        return _namesList;
        }
        set
        {
        if (value == _namesList)
        {
        return;
        }
        _namesList = value;
        }
    }

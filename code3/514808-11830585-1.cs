    private String _owner;
    public String Owner
    {
        get { return _owner; }
        set { _owner = NullIfEmpty(value); } 
    }
    ...
    public String NullIfEmpty(string str) 
    {
        return str == String.Empty ? null : str;
    }

    private string _value;
    
    public string value
    {
        get { return _value; }
        set
        {
          _value = value;
          OnPropertyChanged(_value);
        }
    }

    private string _symbol;
    
    public string Symbol {
        get { return _symbol; }
        set { 
            _symbol = value;
            if (_symbol != null ) {
                // here the _symbol is right after deserialization,
                // and is certainly not null
            }
        }
    }

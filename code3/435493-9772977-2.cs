    _displayError = (s) => { throw new ArgumentNullException("Please tell me what to do with this exception!"); };
    public Action<string> DisplayError
    {
        set 
        {
            if (value == null) { throw new ArgumentNullException("I need this!"); }
            _displayError = value;
        }
    }
    public void MyMethod()
    {
        _displayError("ERROR");
    }
    

    public string WBD10 
    {
        get { return _wbd10; }
        set
        {
            if (!String.IsNullOrEmpty(value))
                _wbd10 = value.PadLeft(10, '0');
            // If value is null, take some other action (or do nothing)
        }
    }

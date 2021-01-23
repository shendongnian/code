    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            if (!Regex.IsMatch(value, @"^[\d\.]+$"))
            {
                throw new ApplicationException("Please enter only numbers/decimals.");
            }
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            if (!Regex.IsMatch(value, @"^((?:[1-9]\d*)|(?:(?=[\d.]+)(?:[1-9]\d*|0)\.\d+))$"))
            {
                throw new ApplicationException("Please enter only numbers/decimals.");
            }
        }
    }

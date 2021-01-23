    public string MyString
    {
        get
        {
            return _someString;
        }
        set
        {
            if (value == "a" || value == "b" /* ... */)
                _someString = value;
            else
                throw new InvalidArgumentException("Invalid value!");
        }
    }

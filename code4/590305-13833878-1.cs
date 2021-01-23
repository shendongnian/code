    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.ToLower() == "bilbo")
                _name = "Bilbo Baggins";
        }
    }

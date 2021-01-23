    public string Name
    {
        get
        {
            if (!CanReadProperty("Name")) { return string.Empty; } // or return null, whatever...
            return _name;
        }
    }

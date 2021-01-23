    public string Name
    {
        get{ return name; }
        set
        {
            value != null ? name = value : throw new ArgumentNullException("Bla");
        }
    }

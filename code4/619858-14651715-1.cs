    private Guid id;
    public Guid Id
    {
        get { return id; }
        set
        { 
            if (checkValue(value)==true)
            {
                id = value;
            } 
        }
    }

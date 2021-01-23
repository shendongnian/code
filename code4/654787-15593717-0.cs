    public int Iterator
    {
        get
        {
            
            return iterator;
        }
        set
        {
            iterator = value;
            if (iterator > Items.Count  - 1) iterator = 0;
            if (iterator < 0) iterator = Items.Count  - 1;
        }
    }
    
    public List<string> Items
    {
        get; set;
    }

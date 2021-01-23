    public String Name
    {
        get 
        {
            return this.name; 
        }
        
        set 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentOutOfRangeException("value");
                
            this.name = value;
        }
    }

    public String Name
    {
        get 
        {
            return this.name; 
        }
        
        set 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("value");
                
            this.name = value;
        }
    }

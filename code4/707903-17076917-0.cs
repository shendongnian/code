    private double a;
    
    public double PropertyA
    {
        get
        {
            return a;
        }
        set
        {
            if (a != value)
            {
                a = value;
                // fire event
                PropertyChanged("PropertyA");
            }
        }
    }
    
    // when changing a, make sure to use the property instead...
    PropertyA = 5.2;

    private double a;
    
    public double PropertyA
    {
        get
        {
            return a;
        }
        set
        {
            // set value and fire event only when value is changed
            // if we want to know when value set is the same then remove if condition
            if (a != value)
            {
                a = value;
                PropertyChanged("PropertyA");
            }
        }
    }
    
    // when changing a, make sure to use the property instead...
    PropertyA = 5.2;

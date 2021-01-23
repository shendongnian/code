    private int myPropertyValue;
    
    public int MyProperty
    {
        get 
        {
            return myPropertyValue;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                myPropertyValue = value;
            }
            else
            {
                // throw exception here.
            }
        }
    }

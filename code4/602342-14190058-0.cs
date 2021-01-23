    public event Action<bool> BoolChangeEvent;
    public Boolean booleanValue;
    public bool someMethod(string value)
    {
       // Raise event to signify the bool value has been set.
       BoolChangeEvent(value);
    
       // Do some work in here.
       booleanValue = true;
       return booleanValue;
    }

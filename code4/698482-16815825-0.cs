    public int [] MyIntegers
    {
       ...
    }
    
    public string MyIntegersStringified
    {
        get {
    
           return string.Join(",", MyIntegers);
        }
    }

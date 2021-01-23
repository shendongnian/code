    [Intercept]
    public string Method1(POS pos, int param1, string param2)
    {
        return String.Format("{0}: {1}", param1,param2);
    }
    
    [Intercept]
    public int Method2(POS pos, int param3)
    {
        return param3 * 2;
    }
    
    public bool OnPreProcessing(...)
    {
         // Before Mothod1 and Method2 called, It should enter here
         // I want to be able to cancel method execution and return another value.
         // I want to get the method name, parameter names and values         
    }

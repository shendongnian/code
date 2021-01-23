    public void MethodOne(Delegate MethodCall)
    {
    //some stuff
    
    //Assuming you now have the required parameters
    //or add params object[] args to the signature of this method
    object res = MethodCall.DynamicInvoke(args); //args is object[] representing the parameters
    
    //some stuff
    }

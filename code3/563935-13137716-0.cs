    public void MethodOne(Delegate MethodCall)
    {
    //some stuff
    
    //Assuming you now have the required parameters
    object res = MethodCall.DynamicInvoke(args); //args is object[] representing the parameters
    
    //some stuff
    }

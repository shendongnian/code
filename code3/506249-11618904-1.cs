    public MyObjGroup(MyObj primaryObj) 
    {
        if(primaryObj == null) 
            throw new ArgumentNullException("value", "PrimaryObj cannot be null");
    }
    public MyObjGroup(MyObj primaryObj, MyObj secondaryObj) 
        : this(primaryObj)
    {
        SecondaryObj = secondaryObj;
    }

    public MyObjGroup(MyObj primaryObj) : this(primaryObj, null) { }
    public MyObjGroup(MyObj primaryObj, MyObj secondaryObj) {
        if (primaryObj == null) {
            throw new ArgumentNullException("value", "PrimaryObj cannot be null");
        }
        SecondaryObj = secondaryObj;
        PrimaryObj = primaryObj;
    }
    

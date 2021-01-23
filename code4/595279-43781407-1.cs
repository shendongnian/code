    public static ExtensionClass 
    { 
        public static bool RunExtensionMethod(this object myObject)
        { 
             if(myObject == null) throw new ArgumentNullException(nameof(myObject));
            var someExecutionOnMyObject = myObject.IsValid();
            return someExecutionOnMyObject ;
        }
    }
    public void CallingMethod()
    {
        var myObject = getMyObject();
        if(myObject != null && myObject.RunExtensionMethod())
        {
        }
    }

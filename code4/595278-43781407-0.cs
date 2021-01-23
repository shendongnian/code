    public static ExtensionClass 
    { 
        public static bool RunExtensionMethod(this object myObject)
        { 
            var someExecutionOnMyObject = myObject.IsValid();
            //the above line would invoke the exception when myObject is null
            return someExecutionOnMyObject ;
        }
    }
    public void CallingMethod()
    {
        var myObject = getMyObject();
        if(myObject.RunExtensionMethod()) //This would cause "delete to an instance method cannot have null" if myObject is null
        {
        }
    }

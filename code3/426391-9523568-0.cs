    public object GetDynamicObject()
    {
        var obj = new ExpandoObject();
        obj.DynamicProperty1 = "hello world";
        obj.DynamicProperty2 = 123;
        return obj;
    }
    
    
    // elsewhere in your code:
    
    dynamic myObj = GetDynamicObject();
    string hello = myObj.DynamicProperty1;

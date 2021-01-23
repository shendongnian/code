    public object FooEventHandler(object obj)
    {
        obj.GetType().GetProperty("MyProperty").SetValue(obj, "updated", null);
        return obj;
    }
    

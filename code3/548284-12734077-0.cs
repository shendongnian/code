    public object FooEventHandler(object obj)
    {
        object toReturn = null;
        obj.GetType().GetProperty("MyProperty").SetValue(obj, "updated", null);
        toReturn = obj;
        return toReturn;
    }
    

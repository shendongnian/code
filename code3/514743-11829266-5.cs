    private object GetValueAsObject(string dt, string propValue)
    {
        ...
     
        switch (dt)
        {
            ...
    
            case "r4":
                return Convert.ToSingle(propValue);
    
            case "r8":
                return Convert.ToDouble(propValue);
    
            ...
        }
    
        ...
    }

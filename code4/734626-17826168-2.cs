    public static string GetDisplayAttributeValue()
    {
        System.Attribute[] attrs = 
                System.Attribute.GetCustomAttributes(typeof(MyClass)); 
        foreach (System.Attribute attr in attrs)
        {
            var displayAttribute as Display;
            if (displayAttribute == null)
                continue;
            return displayAttribute.GetName();   
        }
        
        // throw not found exception or just return string.Empty
    }

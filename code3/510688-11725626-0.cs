    public bool isNullableProperty(PropertyInfo p)
    {
        bool result = false;
        foreach (object attr in p.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false))
            if (!(((EdmScalarPropertyAttribute)attr).IsNullable))
                result = true;
        return result;
    }
    public void SetAllNonNullableProperties(System.Data.Objects.DataClasses.EntityObject airport)
    {
        Type t = airport.GetType();
        PropertyInfo[] props = t.GetProperties();
    
        foreach (PropertyInfo p in props)
        {
            if (isNullableProperty(p)) 
                // Now i know the secrets... ;)
    
            if (p.PropertyType() == typeof(DateTime))
                //  This property type is datetime
            else if (p.PropertyType() == typeof(int))
                // And this type is integer
                    
        }
    
    }

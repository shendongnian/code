    public static object GetPropertyAttributes(PropertyInfo prop, string attributeName)
    {
        object[] attrs = prop.GetCustomAttributes(true);
    
        foreach (object attr in attrs)
        {
            //THIS SHOULD BE REFLECTION
            if (attr is IMyCustomAttribute) // check if attr implements interface (you may have to reflect to get this)
            {
                return (attr as IMyCustomAttribute).Value
            }
    
        }
    }
    
    // Your interface
    public interface IMyCustomAttribute
    {
        object Value { get; set; }
    }
    // Attribute implementing interface
    public SomeCustomAttribute : Attribute, IMyCustomAttribute
    {
        object Value { get; set; }
        // Other attribute code goes here
    }

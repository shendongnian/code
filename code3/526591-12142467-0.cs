    Type myType =(typeof(MyTypeClass));
    // Get the public properties.
    PropertyInfo[] myPropertyInfo = myType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
    
    for(int i=0;i<myPropertyInfo.Length;i++)
    {
        PropertyInfo myPropInfo = (PropertyInfo)myPropertyInfo[i];
        Console.WriteLine("The property name is {0}.", myPropInfo.Name);
        Console.WriteLine("The property type is {0}.", myPropInfo.PropertyType);
    }

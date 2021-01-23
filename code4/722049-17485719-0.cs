    Type MyType = typeof(ICompanyRet);                          
    PropertyInfo[] properties = MyType.GetProperties();                
    Console.Write("\nThere are {0} properties in {1}", properties.Length, MyType.Name);
    foreach (PropertyInfo property in properties)                
    {
        Console.Write("\n" + property.Name);
    }

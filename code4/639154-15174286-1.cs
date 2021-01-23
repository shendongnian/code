    public Type[] PredefinedTypes = new Type[]
    {
        typeof(System.SByte),
        typeof(System.Byte), 
        typeof(System.Int16), 
        typeof(System.UInt16), 
        typeof(System.Int32), 
        typeof(System.UInt32), 
        typeof(System.Int64), 
        typeof(System.UInt64), 
        typeof(System.Single), 
        typeof(System.Double), 
        typeof(System.Decimal),
        typeof(System.DateTime),
        typeof(System.Guid)
    };
    public dynamic ConvertToType(string value)
    {
        foreach (var predefinedType in PredefinedTypes.Where(t => t.GetMethods().Any(m => m.Name.Equals("TryParse"))))
        {
            var typeInstance = Activator.CreateInstance(predefinedType);
            if (predefinedType.GetMethods().Any(m => m.Name.Equals("TryParse")))
            {
                object[] methodArgs = new object[] { value, typeInstance };
                if (((bool)predefinedType.GetMethod("TryParse", new Type[] { typeof(string), predefinedType.MakeByRefType() })
                                         .Invoke(predefinedType, methodArgs )) == true)
                {
                    return methodArgs[1];
                }
            }
        }
        return value;
    }

    object obj = Activator.CreateInstance(type);
    
    foreach (var propertyName in propertyNames)
    {
        PropertyInfo pi = type.GetProperty(propertyName);
        Console.WriteLine(pi.GetValue(obj));
    }
    dynamic testObj = obj;
    Console.WriteLine(testObj.MyTestProperty2);

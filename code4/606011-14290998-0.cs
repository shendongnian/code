    System.Type type = typeof(Person);
    System.Reflection.PropertyInfo[] properties = type.GetProperties();
    
    foreach (System.Reflection.PropertyInfo property in properties)
        Console.WriteLine(property.Name);

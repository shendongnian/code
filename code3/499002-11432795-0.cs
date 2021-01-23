    var nonGenericProperties = typeof(Person)
        .GetProperties()
        .Where(p => !p.IsGenericType)
        .ToList();
    
    var nonGenericClassesWhichInheritFromPerson = Assembly.GetAssembly(typeof(Person))
        .GetTypes()
        .Where(t => t.IsSubclassOf(typeof(Person))
        .ToList()
      

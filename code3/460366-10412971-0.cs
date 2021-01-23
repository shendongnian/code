    var list = new List<MyClass>();
    // Gets an object to give us access to the property with the given name of type MyClass
    var propertyInfo = typeof(MyClass).GetProperty(propertyName);
    // Each item is ordered by the value of the property
    list = list.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();

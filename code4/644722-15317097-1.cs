    List<Reflection.PropertyInfo> myProperties = new List()<object>
    {
        typeof(SomeType).GetProperty("prop1"), 
        typeof(SomeType).GetProperty("prop2"), 
        typeof(SomeType).GetProperty("prop3"), 
        typeof(SomeType).GetProperty("prop4"), 
        typeof(SomeType).GetProperty("prop5"), 
        typeof(SomeType).GetProperty("prop6")
    };
    foreach(var p in myProperties)
    {
        var value = p.GetValue(someObject, new object[0]);
        myList.Add(p);
    }

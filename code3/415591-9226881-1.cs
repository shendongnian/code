    var target = new MyObject();
    
    foreach(var property in target.GetType().GetProperties())
    {
        Type propertyType = property.PropertyType;
        object actual = property.GetValue(target, null);
        object expected = propertyType.IsValueType
            ? Activator.CreateInstance(propertyType)
            : null;
        Assert.AreEqual(expected, actual);
    }

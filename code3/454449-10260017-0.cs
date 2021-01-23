    [Test]
    public void Id_IsMarkedWithKeyAttribute()
    {
        var propertyInfo = typeof(MyClass).GetProperty("Id");
 
        var attribute = propertyInfo.GetCustomAttributes(typeof(KeyAttribute))
            .Cast<KeyAttribute>()
            .FirstOrDefault();
 
        Assert.That(attribute, Is.Not.Null);
    }

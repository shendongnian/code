    [Test]
    public void Id_IsMarkedWithKeyAttribute()
    {
        var propertyInfo = typeof(MyClass).GetProperty("Id");
 
        var attribute = propertyInfo.GetCustomAttributes(typeof(KeyAttribute), true)
            .Cast<KeyAttribute>()
            .FirstOrDefault();
 
        Assert.That(attribute, Is.Not.Null);
    }

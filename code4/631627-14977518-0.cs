    TestClass obj = new TestClass();
    Type t = typeof(TestClass);
    foreach (var property in t.GetProperties())
    {
        var value = property.GetValue(obj);
    }

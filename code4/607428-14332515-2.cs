    [Test]
    public void MyTest([Values("A","B")] string propName)
    {
        var myClass = new MyClass();
        var value = myClass.GetType().GetProperty(propName).GetValue(myClass, null);
        // test value
    }

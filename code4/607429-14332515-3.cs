    [Test]
    public void MyTest()
    {
        var myClass = new MyClass();
        MyPropertyTest(myClass.First);
        MyPropertyTest(myClass.Second);
        MyPropertyTest(myClass.Third);
    }
    public void MyPropertyTest(string value)
    {
        // Assert on string
    }

    [Test]
    public void MyTest()
    {
        var testObject = new MyClass();
        Assert.That(testObject, Has.Property("First").EqualTo("foo"));
        Assert.That(testObject, Has.Property("Second").EqualTo(42));
        Assert.That(testObject, Has.Property("Third").EqualTo(3.14));
    }

    [TestCase("First", "foo"]
    [TestCase("Second", 42]
    [TestCase("Third", 3.14]
    public void MyTest(string name, object expected)
    {
        Assert.That(new MyClass(), Has.Property(name).EqualTo(expected));
    }

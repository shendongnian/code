    [Test]
    [TestCase(new object[] {"foo", "bar", "baz"})]
    [TestCase(new object[] {"300", "500", "700"})]    
    public void MyClass_SomeOtherMethod(params string[] bunchOfStrings)
    {
        // assert something...
    }

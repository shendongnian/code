    public IEnumerable<Type> TestedClasses()
    {
        // We can find the tests for a class, because the test cases references in some special method.
        return new []{typeof(SomeTestedType), typeof(OtherTestedType)};
    }
    [Test]
    public void TestRequirement23423432()
    {
        // ... test code.
        this.TestingMethod(someObject.methodBeingTested); //We do something similar for methods if we want to track which methods are being tested (we usually don't)
        // ... 
    }

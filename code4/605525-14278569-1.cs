    [TestCaseSource(typeof(InputData), "_keywords")]
    public void MethodShouldNotThrowForValidValues(MyEnum value)
    {
        var sut = new MyClass();
    
        sut.MyMethod(value);
    
        Assert.True(true);
    }

    [TestCaseSource(typeof(InputData), "_keywords")]
    public void MethodShouldNotThrowForValidValues(KeyValuePair<string, string> value)
    {
        var sut = new MyClass();
    
        sut.MyMethod(value);
    
        Assert.True(true);
    }

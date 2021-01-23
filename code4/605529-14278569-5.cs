    [TestCaseSource(typeof(InputData), "_keywords")]
    public void MethodShouldNotThrowForValidValues(KeyValuePair<string, string> value)
    {
        var sut = new MyClass();
    
        var val = sut.MyMethod(value);
    
        Assert.True(val);
    }

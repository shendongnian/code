    [TestCase(MyEnum.ExceptionValue1)]
    [TestCase(MyEnum.ExceptionValue2)]
    [TestCase(MyEnum.ExceptionValue3)]
    [ExpectedException(typeof(MyException))]
    public void MethodShouldThrowForInvalidValues(MyEnum value)
    {
        var sut = new MyClass();
    
        sut.MyMethod(value);
        Assert.True(true);
    }
    [TestCase(MyEnum.ValidValue1)]
    [TestCase(MyEnum.ValidValue2)]
    [TestCase(MyEnum.ValidValue3)]
    public void MethodShouldNotThrowForValidValues(MyEnum value)
    {
        var sut = new MyClass();
    
        sut.MyMethod(value);
        Assert.True(true);
    }

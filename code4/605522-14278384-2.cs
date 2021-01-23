    [Test]
    [TestCaseSource("InvalidEnumValues")]
    public void MethodShouldThrowForInvalidValues(MyEnum value)
    {
        var sut = new MyClass();
    
        Assert.Throws<MyException>(() => sut.MyMethod(value));
    }
    public IEnumerable<MyEnum> InvalidEnumValues
    {
        get
        {
            // here you can put a foreach if you like
        }
    }

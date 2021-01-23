    enum ABigEnum
    {
        A,
        B,
        C,
        D
    }
    
    [Theory]
    public void Test(ABigEnum enumValue)
    {
        bool someValue = enumValue != ABigEnum.D;
        Assert.That(someValue, Is.True, "an amazing assertion message");
    }
    

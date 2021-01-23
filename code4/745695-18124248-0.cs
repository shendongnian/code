    [Theory]
    public void Test(ABigEnum enumValue)
    {
    //generate someValue based upon enumValue    
    bool truthValue = IsD(enumValue);
    Assert.That(someValue, Is.EqualTo(truthValue), "an amazing assertion message");
    }
    
    IsD(ABigEnum enumValue)
    {
        return (enumValue==ABigEnum.D)
    }

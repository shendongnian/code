    public void InitializeTest(string value)
    {
        //set env var with value
    }
    [TestCase("Value-1")]
    [TestCase("Value-2")]
    [TestCase("Value-3")]
    public void Test(string value)
    {
        InitializeTest(value);
        //Arange
        //Act
        //Assert
    }

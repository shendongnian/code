    [TestMethod]
    public void Test()
    {
        //Arrange
        var sut = new ClassToTest();
        sut.MethodThatShouldNotThrow();
        //Act
        try
        {
             sut.MethodToTestThatShuldThrow();
        }
        catch(InvalidOperationException ioex)
        {
            //Assert, here you could do additional Asserts on the Exception's properties      
            return;
        }
        Assert.Fail("Expected InvalidOperationException was not thrown");
    }

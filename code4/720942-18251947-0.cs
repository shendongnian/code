    [TestMethod]
    public void MethodName_TestErrorMessage_When_SomeException()
    {
      // Arrange
      const string ExpectedMessgae= "Error in Application ";
      this.MockedInterface.Setup(x=>x.MethodCall()).Throws<SomeException>();
    
      // Act
      var result=this.Controller.Action() as JsonResult;
    
      // Assert
      Assert.AreEqual(ExpectedMessage, result.Data.ToString());
    }

    [Test]
    public void When_user_forgot_password_should_save_user()
    {
        // Arrange
        var errorMessage = string.Empty;
        var dataProvider = MockRepository.GenerateStub<IDataProvider>();
        dataProvider.Stub(x => x.GetData("x", "y", "z", ref errorMessage )).Return(null);
        
        // Act
        var result DoSomething("x","y","z", ref errorMessage, dataProvider);
        
        // Assert
        //...
    }

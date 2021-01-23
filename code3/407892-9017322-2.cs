    [Test]
    public void When_user_forgot_password_should_save_user()
    {
        // Arrange
        var dataProvider = MockRepository.GenerateStub<IDataProvider>();
        dataProvider.Stub(x => x.GetData("x", "y", "z")).Return(null);
        
        // Act
        var result DoSomething("x","y","z",dataProvider);
        
        // Assert
        //...
    }

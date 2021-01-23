    [TestMethod]
    public void Run_Calls_DoSomethingProtected()
    {
        //// Arrange
        // AutoMoqCustomization allows AutoFixture to 
        // be used an an auto-mocking container
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        // simply ask the fixture to create a mock
        var sutMock = fixture.Create<Mock<TestableDummySystem>>();
        //// Act
        // exercise the mock object
        sutMock.Object.Run();
        //// Assert
        // this verification passes!
        sutMock.Verify(x => x.DoSomethingProtectedPublic());
    }

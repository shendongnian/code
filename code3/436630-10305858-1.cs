    [TestMethod]
    public void MakeSureSettingsFactoryIsCalled()
    {
       var settingsFactoryMock = new Mock<SettingsFactory>();
    
       settingsFactoryMock.Setup(f => f.CreateOrGetSettings(), Times.Once).Verifiable();
    
       var subjectUnderTest = new ClassThatUsesSettingsFactory(settingsFactoryMock.Object);
    
       subjectUnderTest.MethodThatCallsSettingsFactory();
    
       settingsFactoryMock.Verify();
    }

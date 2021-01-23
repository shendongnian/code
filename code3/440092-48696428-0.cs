    [Test]
    public void CreateFile_InvalidFileName_ThrowsException()
    {
        //Arrange
        var logger = SetupLogger("?\\");
        //Act
        //Assert
        Assert.That(() => logger.CreateFile(), Throws.InstanceOf<Exception>());
    }

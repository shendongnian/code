    [Test]
    public void Method_ShouldReturnTrueIfPassedNull()
    {
        Assert.That(target.Method(null), Is.True);
    }
    [Test]
    public void Method_ShouldReturnResultOfSomeFunctionIfNotNull()
    {
        // Arrange
        bool expectedResult = false;
        var mock = new Mock<IMyClass>();
        mock.Setup(x => x.SomeFunctionReturningBool()).Return(expectedResult);
        // Act
        var result = target.Method(mock.Object);
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Method_ShouldReturnTrueIfNotPassedNull()
    {
        Assert.That(target.Method(new MyClass()), Is.True);
    }
    [Test]
    public void Method_ShouldCreateObjectAndReturnResultOfSomeFunctionIfPassedNull()
    {
        // Arrange
        bool expectedResult = false;
        var mockMyClass = new Mock<IMyClass>();
        mockMyClass.Setup(x => x.SomeFunctionReturningBool()).Returns(expectedResult);
        var mockMyFactory = new Mock<IMyClassFactory>();
        mockMyFactory.Setup(x => x.CreateMyClass()).Returns(mockMyClass.Object);
        // Act
        var result = target.Method(null, mockMyFactory.Object);
        // Assert
        mockMyClass.Verify(x => x.SomeFunctionReturningBool(), Times.Once());
        mockMyFactory.Verify(x => x.CreateMyClass(), Times.Once());
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ApplyChangesCommand_Always_ReturnsFactoryCreatedCommand
    {
        Mock<ICommand> mockCreatedCustomCommand = new Mock<ICommand>();
        Mock<MyCustomCommandFactory> mockCommandFactory = new Mock<MyCustomCommandFactory>();
        mockCreatedCustomCommand.Setup(p => p.Create(It.IsAny<Action>(), e => true))
                                .Returns(mockCreatedCustomCommand.Object);
        Assert.That(systemUnderTest.ApplyChangesCommand, Is.SameAs(mockCreatedCustomCommand.Object));
    }

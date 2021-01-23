    // Arrange
    Mock<IProcessData> processData = new Mock<IProcessData>();
    processData.Setup(d => d.ProcessOwner).Returns(new[] { "Bob" });
    // Act
    var actual = roles.GetLoginsThatCanCallAction("Drink");
    // Assert
    processData.VerifyGet(d => d.ProcessOwner); // verify communication
    Assert.AreEqual(actual, expected); // verify result

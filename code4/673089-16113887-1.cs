    // Arrange
    Mock<IProcessData> processData = new Mock<IProcessData>();
    processData.Setup(d => d.ProcessOwner).Returns(new[] { "Bob" });
    var expected = new []{ "Bob", "Joe" };
    // Act
    var actual = roles.GetLoginsThatCanCallAction("Drink");
    // Assert
    processData.VerifyGet(d => d.ProcessOwner); // verify communication
    CollectionAssert.AreEquivalent(expected, actual); // verify result

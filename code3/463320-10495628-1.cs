    [TestFixture]
    class Tests
    {
        [Test]
        public void AddAAATest()
        {
            // Arrange
            Mock<ISecondDeep> secondDeep = new Mock<ISecondDeep>();
            secondDeep.Setup(x => x.SomethingToDo(It.IsAny<string>())).Returns(true);
            // Act
            FirstDeep fd = new FirstDeep(secondDeep.Object);
            // Assert
            Assert.That(fd.AddA("ABD"), Is.EqualTo("ABCAAA"));
         }
    }

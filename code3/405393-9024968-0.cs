        [Test]
        public void SetupFunc_TestWithExpectedArgument_ReturnsNotNull()
        {
            // Arrange
            var repository = new Mock<IRepository<Container>>();
            repository.Setup(r => r.Find(It.Is<Func<Container,bool>>(x => x(new Container {Name = "foo"})))).Returns(new Container());
            // Act
            var container = repository.Object.Find(x => x.Name == "foo");
            // Assert
            Assert.That(container, Is.Not.Null);
        }
        [Test]
        public void SetupFunc_TestWithOtherArgument_ReturnsNull()
        {
            // Arrange
            var repository = new Mock<IRepository<Container>>();
            repository.Setup(r => r.Find(It.Is<Func<Container, bool>>(x => x(new Container { Name = "foo" })))).Returns(new Container());
            // Act
            var container = repository.Object.Find(x => x.Name == "bar");
            // Assert
            Assert.That(container, Is.Null);
        }

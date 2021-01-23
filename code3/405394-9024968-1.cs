        [Test]
        public void SetupFunc_TestWithExpectedArgument_ReturnsNotNull()
        {
            // Arrange
            var repository = new Mock<IRepository<Container>>();
            repository.Setup(r => r.Find(It.Is<Expression<Func<Container, bool>>>(x => NameIsFoo(x)))).Returns(new Container());
            // Act
            Container container = repository.Object.Find(x => x.Name == "foo");
            // Assert
            Assert.That(container, Is.Not.Null);
        }
        [Test]
        public void SetupFunc_TestWithOtherargument_ReturnsNull()
        {
            // arrange
            var repository = new Mock<IRepository<Container>>();
            repository.Setup(r => r.Find(It.Is<Expression<Func<Container, bool>>>(x => NameIsFoo(x)))).Returns(new Container());
            // Act
            Container container = repository.Object.Find(x => x.Name == "bar");
            // Assert
            Assert.That(container, Is.Null);
        }
        private static bool NameIsFoo(Expression<Func<Container, bool>> expression)
        {
            if (expression == null)
                return false;
            var mExpr = expression.Body as BinaryExpression;
            if (mExpr == null)
                return false;
            var constantExpression = mExpr.Right as ConstantExpression;
            if (constantExpression == null)
                return false;
            return Equals(constantExpression.Value, "foo");
        }

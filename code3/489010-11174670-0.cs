    using Moq;
    using NUnit.Framework;
    
    namespace ConsoleApplication1
    {
        [TestFixture]
        public class Tests
        {
            [Test]
            public void TestIt()
            {
                // Arrange
                var _mapperMock = new Mock<IMapper<Foo, Bar>>();
                var fooMock = new Mock<Foo>();
                var barMock = new Mock<Bar>();
    
                _mapperMock.Setup(m => m.Map(fooMock.Object)).Returns(barMock.Object);
                _mapperMock.Setup(m => m.Map(barMock.Object)).Returns(fooMock.Object);
    
                // Act
                var bar = _mapperMock.Object.Map(fooMock.Object);
                var foo = _mapperMock.Object.Map(barMock.Object);
    
                // Assert
                Assert.AreSame(bar, barMock.Object);
                Assert.AreSame(foo, fooMock.Object);
    
                _mapperMock.Verify(x => x.Map(fooMock.Object), Times.Once());
                _mapperMock.Verify(x => x.Map(barMock.Object), Times.Once());
            }
        }
    
        public class Bar
        {
        }
    
        public class Foo
        {
        }
    }

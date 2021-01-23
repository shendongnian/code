    [TestFixture]
    public class ExtensionTest
    {
        public class FakeEntity : EntityObject
        {
        }
        [Test]
        public void DeleteAllObjects()
        {
            //arrange
            var objectsToDelete = new List<FakeEntity>
                {
                    new FakeEntity(),
                    new FakeEntity()
                };
            var mockContext = new Mock<ObjectContext>();
            var mockObjectSet = new Mock<ObjectSet<FakeEntity>>();
            mockObjectSet.Setup(x => x.ToList()).Returns(objectsToDelete);
            mockContext.Setup(x => x.CreateObjectSet<FakeEntity>()).Returns(mockObjectSet.Object);
            //act
            mockContext.Object.DeleteAllObjects<FakeEntity>();
            //assert
            mockContext.Verify(x => x.CreateObjectSet<FakeEntity>(), Times.Once());
            mockObjectSet.Verify(x => x.ToList(), Times.Once());
            mockObjectSet.Verify(x => x.DeleteObject(It.IsAny<FakeEntity>()), Times.Exactly(2));
        }
    }

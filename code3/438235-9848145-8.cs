    // Given
    var c1 = new Mock<IMyClass>();
    var c2 = new Mock<IMyClass>();
    // Setup the behavior of the mock objects
    var factory = new Mock<IFactory<IMyClass>>();
    factory.Setup(s => s.Create()).ReturnsInOrder(c1.Object, c2.Object);
        

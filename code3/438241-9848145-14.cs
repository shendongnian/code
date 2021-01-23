        // Given
        var c1 = new Mock<IMyClass>();
        var c2 = new Mock<IMyClass>();
        // TODO: setup the behavior of the mock objects
        var factory = new Mock<IFactory<IMyClass>>();
        factory.Setup(s => s.Create()).ReturnsInOrder(c1.Object, c2.Object);
            
        // When
        var fixture = new Fixture();
        fixture.Inject(() => factory.Object)
        var sut = fixture.CreateAnonymous<SystemUnderTest>();
        
        // Then
        // TODO: verify the expectations on the mock objects

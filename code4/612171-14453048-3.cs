    // Arrange
    var collectorMock = new Mock<IPositionCollector>();
    // Act
    sut.SetPosition(collectorMock.Object, vector)
    // Assert    
    collectorMock.VerifySet(c => c.Position = It.Is<FPosition>(p => 
        p.CoordinateX == vector.X &&
        p.CoordinateY == vector.Y &&
        p.CoordinateZ == vector.Z));

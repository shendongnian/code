    // Arrange
    var collectorMock = new Mock<IPositionCollector>();
    var position = new FPosition
    {
        CoordinateX = vector.X,
        CoordinateY = vector.Y,
        CoordinateZ = vector.Z
    };
    // Act
    sut.SetPosition(collectorMock.Object, vector)
    // Assert
    collectorMock.VerifySet(c => c.Position = position);

    // Arrange
    var collectorMock = new Mock<IPositionCollector>();
    var position = new FPosition
    {
        CoordinateX = vector.X,
        CoordinateY = vector.Y,
        CoordinateZ = vector.Z
    };
    // Act
    SetPosition(mock.Object, vector)
    // Assert
    collectorMock.VerifySet(c => c.Position = position);

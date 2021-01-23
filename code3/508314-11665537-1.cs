    // Arrange
    Mock<ILocationRepository> repository = new Mock<ILocationRepository>();
    var controller = new LocationController(repository.Object);
    Location location = new Location("New York);
    // Act
    var result = controller.Create(location);
    // Assert
    repository.Verify(r => r.Add(location));
    repository.Verify(r => r.Save());
    ...

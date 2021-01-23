    [Test]
    public void AddManufacturer_DoesNotAddExistingManufacturersToDbSet()
    {
        // Arrange
        var stubEntities = MockRepository.GenerateStub<IWsStatContext>();
        var stubManufacturers = MockRepository.GenerateStub<IDbSet<Manufacturer>>();
        var manufacturer = new Manufacturer() { Name = "Dummy" };
        stubManufacturers.Add(manufacturer);
        stubEntities.Manufacturers = stubManufacturers;
        // Act
        var sut = new TestableEquiptmentRepository(stubEntities);
        sut.AddManufacturer(manufacturer);
        // Assert
        Assert.AreEqual(sut.AddedManufacturers.Count(), 0);
    }
  

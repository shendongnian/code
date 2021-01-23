    [Test]
    public void RegionFactoryDelegatesToRegionGenerator()
    {
        var mockGenerator = new Mock<IMapRegiongenerator>();
        var factory = new MapRegionFactory(mockGenerator.Object);
    
        var expectedRegion = new Region();
        var regionSize = CreateRandomRegionSize();
        mockGenerator.Setup(g=>g.GenerateRegion(regionSize)).Returns(expectedRegion);
    
        factory.SetRegionSize(regionSize);
        Assert.That(factory.GetRegion(), Is.SameAs(expectedRegion));
    }

    [TestMethod]
    public void ShouldPassSomeProjectToStock()
    {
        // Arrange
        var products = new List<Product>() { }; // create some products
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(r => r.GetSomeProducts()).Returns(products);
        var mockGateway = new Mock<IStockGateway>();
        mockGateway.Setup(g => g.DoSomethingWithProducts(products));
        var provider = new ProductDataServiceProvider(mockRepository.Object, 
                                                      ockGateway.Object);
        // Act
        provider.ProcessProductFeed();
        // Assert
        mockRepository.VerifyAll(); // verify products retrieved from repository
        mockGateway.VerifyAll(); // verify products passed to gateway
    }

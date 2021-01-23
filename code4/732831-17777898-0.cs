    var configMock = new Mock<IStockServiceConfig>();
    configMock.Setup(c => c.Load()).Throws<FileNotFoundException>();
    StockService service = new StockService(configMock.Object);
    service.Connect("google");
    configMock.VerifyAll();
    Assert.That(service.Port, Is.EqualTo(80));

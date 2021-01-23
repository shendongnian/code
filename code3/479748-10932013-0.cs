    bool isConnected = false
    var mockService = new Mock<IService>();
    // Setup mockService so IsConnected mutates...?
    mockService.Setup(s => s.Connect()).Callback(() => isConnected = true);
    mockService.SetupGet(s => s.IsConnected).Returns(() => isConnected);
    bool before = mockService.Object.IsConnected;
    mockService.Object.Connect();
    bool after = mockService.Object.IsConnected;
    Assert.AreNotEqual(before, after);
